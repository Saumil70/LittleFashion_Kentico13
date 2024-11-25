using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMS.Core;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Routing;
using Kentico.Content.Web.Mvc;
using CMS.SiteProvider;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using LittleFashion_Kentico13.ViewModel.Footer;

namespace LittleFashion_Kentico13.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public FooterViewComponent(IPageRetriever pageRetriever, IPageUrlRetriever pageUrlRetriever)
        {
            // Initializes instances of required services using dependency injection
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Retrieves a collection of page objects with data for the menu (pages of all page types)
            IEnumerable<TreeNode> menuItems = await pageRetriever.RetrieveAsync<TreeNode>(query => query
                                                    // Selects pages that have the 'Show in menu" flag enabled
                                                    .MenuItems()
                                                    // Only loads pages from the first level of the site's content tree
                                                    .NestingLevel(1)
                                                    // Filters the query to only retrieve required columns
                                                    .Columns("DocumentName", "NodeID", "NodeSiteID")
                                                    // Loads pages together with their URL path data (performance reasons)
                                                    .WithPageUrlPaths()
                                                    // Uses the menu item order from the content tree
                                                    .OrderByAscending("NodeOrder"));

            Footer footerData = (await pageRetriever.RetrieveAsync<Footer>(
                query => query
                    .TopN(1) // Only retrieves the first footer page
                    .Columns("CopyRightText", "SitemapText", "SocialText")
            )).FirstOrDefault();

            IEnumerable<SocialLinks> socialLinksData = await pageRetriever.RetrieveAsync<SocialLinks>(
    query => query.Columns("SocialLinkText", "SocialLink"));


            // Get the current site name
            string siteName = SiteContext.CurrentSiteName;


            // Create a collection of menu item view models
            List<MenuItemViewModel> menuItemModels = menuItems.Select(item => new MenuItemViewModel()
            {
                MenuItemText = item.DocumentName, // Menu item caption text
                MenuItemRelativeUrl = pageUrlRetriever.Retrieve(item).RelativePath // Relative URL path
            }).ToList();

            List<SocialLinksViewModel> socialLinksViewModels = socialLinksData.Select(socialLink => new SocialLinksViewModel
            {
                SocialLinkText = socialLink.SocialLinkText,
                SocialLink = socialLink.SocialLink
            }).ToList();

            // Create the header view model
            FooterViewModel footerModel = new FooterViewModel()
            {
                MenuItems = menuItemModels,
                SiteName = siteName,
                CopyRightText = footerData.CopyRightText,
                SitemapText = footerData.SitemapText,
                SocialText = footerData.SocialText,
                SocialLinks = socialLinksViewModels
            };
            // Return the model to the view
            return View(footerModel);
        }
    }
}
