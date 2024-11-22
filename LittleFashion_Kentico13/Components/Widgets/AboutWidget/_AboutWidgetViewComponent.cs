using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.AboutWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.ABOUT_WIDGET, typeof(_AboutWidgetViewComponent), "About Widget", typeof(_AboutWidgetProperties), Description = "Displays the About Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.AboutWidget
{
    public class _AboutWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _AboutWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_AboutWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/AboutWidget/_AboutWidget.cshtml", new _AboutWidgetModel
            {
                ID = properties.ID,
                Heading = properties.Heading,
                RichTextContent = properties.RichTextContent,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                ImageUrl = GetImagePath(properties),
                YoutubeLink = properties.YoutubeLink
            });
        }

        private string GetImagePath(_AboutWidgetProperties properties)
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