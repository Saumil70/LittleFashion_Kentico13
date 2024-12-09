using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FrontProduct;
using LittleFashion_Kentico13.Components.Widgets.StoryBannerWidget;
using LittleFashion_Kentico13.Components.Widgets.TeamSectionWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.TEAMSECTION_WIDGET, typeof(_TeamSectionWidgetViewComponent), "Team Section Widget", typeof(_TeamSectionWidgetProperties), Description = "Displays the Team Section Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.TeamSectionWidget
{
    public class _TeamSectionWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _TeamSectionWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_TeamSectionWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            _TeamSectionWidgetModel model = new _TeamSectionWidgetModel
            {
                TeamMemberName = properties.TeamMemberName,
                TeamMemberPosition = properties.TeamMemberPosition,
                ImageUrl = GetImagePath(properties),
            };

            return View("~/Components/Widgets/TeamSectionWidget/_TeamSectionWidget.cshtml", model);
        }
        private string GetImagePath(_TeamSectionWidgetProperties properties)
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