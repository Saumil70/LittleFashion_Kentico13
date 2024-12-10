using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FAQsWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.FAQs_WIDGET, typeof(_FAQsWidgetViewComponent), "FAQs Widget", typeof(_FAQsWidgetProperties), Description = "Displays the FAQs Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.FAQsWidget
{
    public class _FAQsWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _FAQsWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(_FAQsWidgetProperties properties)
        {
            var zoneId = ViewData["ZoneId"] as string;

            return View("~/Components/Widgets/FAQsWidget/_FAQsWidget.cshtml", new _FAQsWidgetModel
            {
                Question = properties.Question,
                Answer = properties.Answer,
                ZoneId = zoneId
            });
        }
    }
}