using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.AboutWidget
{
    public class _AboutWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "ID", Order = 0)]
        public string ID { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Heading", Order = 1)]
        public string Heading { get; set; }

        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Rich Text Content", Order = 6)]
        public string RichTextContent { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Label = "Button Url", Order = 3)]
        public string ButtonUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Button Text", Order = 4)]
        public string ButtonText { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Background Image", Order = 5)]
        public IEnumerable<MediaFilesSelectorItem> ImageUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "YoutubeLink", Order = 0)]
        public string YoutubeLink { get; set; }
    }
}
