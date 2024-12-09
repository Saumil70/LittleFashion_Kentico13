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
using LittleFashion_Kentico13.Components.Widgets.TestimonialWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.TESTIMONIAL_WIDGET, typeof(_TestimonialWidgetViewComponent), "Testimonial Widget", typeof(_TestimonialWidgetProperties), Description = "Displays the testimonial Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.TestimonialWidget
{
    public class _TestimonialWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _TestimonialWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_TestimonialWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            _TestimonialWidgetModel model = new _TestimonialWidgetModel
            {
                TeamMemberName = properties.TeamMemberName,
                TestimonialMessage = properties.TestimonialMessage,
                ImageUrl = GetImagePath(properties),
            };

            return View("~/Components/Widgets/TestimonialWidget/_TestimonialWidget.cshtml", model);
        }
        private string GetImagePath(_TestimonialWidgetProperties properties)
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