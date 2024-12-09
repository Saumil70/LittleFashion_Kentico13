using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.FrontProduct;
using LittleFashion_Kentico13.Components.Widgets.ModalWidget;
using LittleFashion_Kentico13.Components.Widgets.StoryBannerWidget;
using LittleFashion_Kentico13.Components.Widgets.TeamSectionWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.MODAL_WIDGET, typeof(_ModalWidgetViewComponent), "Modal Widget", typeof(ModalWidgetProperties), Description = "Displays the Modal Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.ModalWidget
{
    public class _ModalWidgetViewComponent : ViewComponent
    {
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;

        public _ModalWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        public ViewViewComponentResult Invoke(ModalWidgetProperties properties)
        {
            _ModalWidgetModel model = new _ModalWidgetModel
            {
                TeamMemberName = properties.TeamMemberName,
                TeamMemberPosition = properties.TeamMemberPosition,
                Description = properties.Description,
                BodyContent = properties.BodyContent,
            };

            return View("~/Components/Widgets/ModalWidget/_ModalWidget.cshtml", model);
        }
    }
}