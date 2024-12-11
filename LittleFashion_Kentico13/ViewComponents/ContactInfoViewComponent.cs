using CMS.DocumentEngine;
using CMS.DocumentEngine.Routing;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using LittleFashion_Kentico13.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleFashion_Kentico13.ViewComponents
{
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public ContactInfoViewComponent(IPageRetriever pageRetriever, IPageUrlRetriever pageUrlRetriever)
        {
            // Initializes instances of required services using dependency injection
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Retrieve the ContactInfo items
            var contactFormData = await pageRetriever.RetrieveAsync<ContactInfo>(
                query => query
                    .Path("/Contact", PathTypeEnum.Children) // Adjust the path to match your site structure
                    .OnCurrentSite()
            );

            // Initialize the final model list
            var model = new List<ContactInfoViewModel>();

            // Loop through the retrieved items
            foreach (var item in contactFormData)
            {
                // Create a new ViewModel instance
                var contactInfoViewModel = new ContactInfoViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    ButtonText = item.ButtonText,
                    ButtonLink = item.ButtonLink,
                    SocialLinks = (item.Fields.SocialLinks != null && item.Fields.SocialLinks.Any())
                        ? await GetSocialLinksAsync(item.Fields.SocialLinks)
                        : null
                };

                // Add the ViewModel to the list
                model.Add(contactInfoViewModel);
            }

            // Pass the data to the view
            return View(model);
        }

        private async Task<List<SocialLinkViewModel>> GetSocialLinksAsync(IEnumerable<TreeNode> socialLinks)
        {
            var socialLinksData = new List<SocialLinkViewModel>();

            // Ensure socialLinks is not null or empty
            if (socialLinks != null && socialLinks.Any())
            {
                foreach (var pageReference in socialLinks)
                {
                    // Retrieve the child SocialLinks items
                    var retrievedLinks = await pageRetriever.RetrieveAsync<SocialLinks>(
                        query => query
                            .Path(pageReference.NodeAliasPath, PathTypeEnum.Children)
                            .OnCurrentSite()
                    );

                    // Map the retrieved links to a view model
                    socialLinksData.AddRange(
                        retrievedLinks.Select(link => new SocialLinkViewModel
                        {
                            SocialLinkText = link.SocialLinkText,
                            SocialLink = link.SocialLink
                        })
                    );
                }
            }

            return socialLinksData;
        }

    }
}
