using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FeaturedProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.FEATUREDPRODUCT_WIDGET, typeof(_FeaturedProductWidgetViewComponent), "Featured Product Widget", typeof(_FeaturedProductWidgetProperties), Description = "Displays the Featured Product Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.FeaturedProduct
{
    public class _FeaturedProductWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _FeaturedProductWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_FeaturedProductWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/FeaturedProductsWidget/_FeaturedProductWidget.cshtml", new _FeaturedProductWidgetModel
            {
                ProductName = properties.ProductName,
                ProductDescription = properties.ProductDescription,
                ProductPrice = properties.ProductPrice,
                ProductUrl = properties.ProductUrl,
                ImageUrl = GetImagePath(properties),
            });
        }

        private string GetImagePath(_FeaturedProductWidgetProperties properties)
        {
            if (properties.ImageUrl == null)
            {
                return null;
            }

            var imageGuid = properties.ImageUrl.FirstOrDefault()?.FileGuid ?? Guid.Empty;
            if (imageGuid == Guid.Empty)
            {
                return null;
            }

            var image = mediaFileProvider.Get(imageGuid, SiteContext.CurrentSiteID);
            if (image == null)
            {
                return string.Empty;
            }

            return fileUrlRetriever.Retrieve(image).RelativePath;
        }
    }
}