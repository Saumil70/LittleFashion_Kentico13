using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.ProductWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.PRODUCT_WIDGET, typeof(_ProductWidgetViewComponent), "Product Widget", typeof(_ProductWidgetProperties), Description = "Displays the Product Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.ProductWidget
{
    public class _ProductWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _ProductWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_ProductWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/ProductsWidget/_ProductWidget.cshtml", new _ProductWidgetModel
            {
                ProductName = properties.ProductName,
                ProductDescription = properties.ProductDescription,
                ProductPrice = properties.ProductPrice,
                ProductUrl = properties.ProductUrl,
                ImageUrl = GetImagePath(properties),
                ProductStatus = properties.ProductStatus,
            });
        }

        private string GetImagePath(_ProductWidgetProperties properties)
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