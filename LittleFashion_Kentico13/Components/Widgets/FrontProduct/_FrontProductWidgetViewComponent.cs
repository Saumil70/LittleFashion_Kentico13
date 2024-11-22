using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FrontProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.SINGLE_COLUMN_SECTION, typeof(_FrontProductWidgetViewComponent), "Front Product Widget", typeof(_FrontProductWidgetProperties), Description = "Displays the About Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.FrontProduct
{
    public class _FrontProductWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _FrontProductWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_FrontProductWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/FrontProductWidget/_FrontProductWidget.cshtml", new _FrontProductWidgetModel
            {
                Heading = properties.Heading,
                Description = properties.Description,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                ImageUrl = GetImagePath(properties),
            });
        }

        private string GetImagePath(_FrontProductWidgetProperties properties)
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