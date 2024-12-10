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
using LittleFashion_Kentico13.Components.Sections.ProductSection;

[assembly: RegisterSection(ComponentIdentifiers.PRODUCT_SECTION, typeof(ProductSectionViewComponent), "Product Section", typeof(ProductSectionProperties), Description = "Product section with dynamic content.", IconClass = "icon-square")]
namespace LittleFashion_Kentico13.Components.Sections.ProductSection
{
    public class ProductSectionViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public ProductSectionViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(ProductSectionProperties properties)
        {
            ProductSectionModel model = new ProductSectionModel
            {
                FirstTitle = properties.FirstTitle,
                SecondTitle = properties.SecondTitle,
            };
            return View("~/Components/Sections/ProductSection/_ProductSection.cshtml", model);
        }
    }
}
