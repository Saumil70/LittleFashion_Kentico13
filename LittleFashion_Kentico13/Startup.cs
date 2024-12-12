using CMS.Helpers;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.Membership;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using LittleFashion_Kentico13.Repository.Home;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using LittleFashion_Kentico13;
using Microsoft.AspNetCore.Localization.Routing;
using LittleFashion_Kentico13.Repository.Inventory;

namespace BlankSiteCore
{
    public class Startup
    {
        private const string AUTHENTICATION_COOKIE_NAME = "identity.authentication";

        public IWebHostEnvironment Environment { get; }


        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable desired Kentico Xperience features
            var kenticoServiceCollection = services.AddKentico(features =>
            {
                features.UsePageBuilder();
                // features.UseActivityTracking();
                // features.UseABTesting();
                // features.UseWebAnalytics();
                // features.UseEmailTracking();
                // features.UseCampaignLogger();
                // features.UseScheduler();
                features.UsePageRouting();
            });

            if (Environment.IsDevelopment())
            {
                // By default, Xperience sends cookies using SameSite=Lax. If the administration and live site applications
                // are hosted on separate domains, this ensures cookies are set with SameSite=None and Secure. The configuration
                // only applies when communicating with the Xperience administration via preview links. Both applications also need 
                // to use a secure connection (HTTPS) to ensure cookies are not rejected by the client.
                kenticoServiceCollection.SetAdminCookiesSameSiteNone();

                // By default, Xperience requires a secure connection (HTTPS) if administration and live site applications
                // are hosted on separate domains. This configuration simplifies the initial setup of the development
                // or evaluation environment without a the need for secure connection. The system ignores authentication
                // cookies and this information is taken from the URL.
                kenticoServiceCollection.DisableVirtualContextSecurityForLocalhost();
            }

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddControllersWithViews();
            services.AddScoped<HomeRepository>();
            services.AddScoped<InventoryRepository>();

            services.AddLocalization()
                    .AddControllersWithViews()
                    .AddViewLocalization()
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResources));
                    });

            services.Configure<KenticoRequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider
                {
                    RouteDataStringKey = "culture",
                    UIRouteDataStringKey = "culture"
                });
            });

            ConfigureMembershipServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseKentico();

            app.UseCookiePolicy();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Kentico().MapRoutes();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
                endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("The site has not been configured yet.");
                //});
            });
        }


        private static void ConfigureMembershipServices(IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<ApplicationUser>, Kentico.Membership.PasswordHasher<ApplicationUser>>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddApplicationIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Note: These settings are effective only when password policies are turned off in the administration settings.
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
                    .AddApplicationDefaultTokenProviders()
                    .AddUserStore<ApplicationUserStore<ApplicationUser>>()
                    .AddRoleStore<ApplicationRoleStore<ApplicationRole>>()
                    .AddUserManager<ApplicationUserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>();

            services.AddAuthorization();
            services.AddAuthentication();

            services.ConfigureApplicationCookie(c =>
            {
                c.Events.OnRedirectToLogin = ctx =>
                {
                    // Redirects to login page respecting the current culture
                    var factory = ctx.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
                    var urlHelper = factory.GetUrlHelper(new ActionContext(ctx.HttpContext, new RouteData(ctx.HttpContext.Request.RouteValues), new ActionDescriptor()));
                    var url = urlHelper.Action("Login", "Account") + new Uri(ctx.RedirectUri).Query;

                    ctx.Response.Redirect(url);

                    return Task.CompletedTask;
                };
                c.ExpireTimeSpan = TimeSpan.FromDays(14);
                c.SlidingExpiration = true;
                c.Cookie.Name = AUTHENTICATION_COOKIE_NAME;
            });

            CookieHelper.RegisterCookie(AUTHENTICATION_COOKIE_NAME, CookieLevel.Essential);
        }


    }
}
