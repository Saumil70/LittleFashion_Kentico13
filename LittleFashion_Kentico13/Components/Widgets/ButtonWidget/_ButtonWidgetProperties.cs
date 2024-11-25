using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.ButtonWidget
{
    public class _ButtonWidgetProperties : IWidgetProperties
    {
        [EditingComponent(UrlSelector.IDENTIFIER, Label = "Button Url", Order = 1)]
        public string ButtonUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Button Text", Order = 2)]
        public string ButtonText { get; set; }
    }
}
