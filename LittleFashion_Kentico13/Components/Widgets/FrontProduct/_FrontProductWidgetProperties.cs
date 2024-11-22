using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.FrontProduct
{
    public class _FrontProductWidgetProperties : IWidgetProperties
    {

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Heading", Order = 1)]
        public string Heading { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Rich Text Content", Order = 6)]
        public string Description { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Label = "Button Primary", Order = 3)]
        public string ButtonUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Button Text", Order = 4)]
        public string ButtonText { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Background Image", Order = 5)]
        public IEnumerable<MediaFilesSelectorItem> ImageUrl { get; set; }
    }
}
