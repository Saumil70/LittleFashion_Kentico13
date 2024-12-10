using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Sections.FAQsSection;

[assembly: RegisterSection(ComponentIdentifiers.FAQs_SECTION, typeof(FAQsSectionViewComponent), "FAQs Section", typeof(FAQsSectionProperties), Description = "FAQs section with dynamic content.", IconClass = "icon-square")]
namespace LittleFashion_Kentico13.Components.Sections.FAQsSection
{
    public class FAQsSectionViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public FAQsSectionViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(FAQsSectionProperties properties)
        {
            FAQsSectionModel model = new FAQsSectionModel
            {
                GeneralFAQsTitle = properties.GeneralFAQsTitle,
                ProductFAQsTitle = properties.ProductFAQsTitle,
            };
            return View("~/Components/Sections/FAQsSection/_FAQsSection.cshtml", model);
        }
    }
}
