﻿using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FrontProduct;
using LittleFashion_Kentico13.Components.Widgets.StoryBannerWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.STORYBANNER_WIDGET, typeof(_StoryBannerWidgetViewComponent), "Story Banner Widget", typeof(_StoryBannerWidgetProperties), Description = "Displays the Story Banner Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.StoryBannerWidget
{
    public class _StoryBannerWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _StoryBannerWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_StoryBannerWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/StoryBannerWidget/_StoryBannerWidget.cshtml", new _StoryBannerWidgetModel
            {
                Heading = properties.Heading,
                ImageUrl = GetImagePath(properties),
            });
        }

        private string GetImagePath(_StoryBannerWidgetProperties properties)
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