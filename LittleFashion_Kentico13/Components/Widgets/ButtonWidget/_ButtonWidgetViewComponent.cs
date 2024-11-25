using System;
using System.Linq;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Widgets.ButtonWidget;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ComponentIdentifiers.BUTTON_WIDGET, typeof(_ButtonWidgetViewComponent), "Button Widget", typeof(_ButtonWidgetProperties), Description = "Displays the Button Widget", IconClass = "icon-square")]

namespace LittleFashion_Kentico13.Components.Widgets.ButtonWidget
{
    public class _ButtonWidgetViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(_ButtonWidgetProperties properties)
        {
            return View("~/Components/Widgets/ButtonWidget/_ButtonWidget.cshtml", new _ButtonWidgetModel
            {
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,            
            });
        }
    }
}