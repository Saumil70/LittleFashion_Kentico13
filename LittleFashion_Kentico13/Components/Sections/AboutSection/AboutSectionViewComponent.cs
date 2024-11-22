using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Sections.AboutSection;

[assembly: RegisterSection(ComponentIdentifiers.ABOUT_SECTION, typeof(AboutSectionViewComponent), "About Section", typeof(AboutSectionProperties), Description = "About section with dynamic content.", IconClass = "icon-square")]
namespace LittleFashion_Kentico13.Components.Sections.AboutSection
{
    public class AboutSectionViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public AboutSectionViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(AboutSectionProperties properties)
        {
            AboutSectionModel model = new AboutSectionModel
            {
                AboutSectionTitle = properties.AboutSectionTitle,
            };
            return View("~/Components/Sections/AboutSection/_AboutSection.cshtml", model);
        }
    }
}
