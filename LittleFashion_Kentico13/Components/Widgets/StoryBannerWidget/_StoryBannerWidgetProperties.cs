using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.StoryBannerWidget
{
    public class _StoryBannerWidgetProperties : IWidgetProperties
    {

        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Banner Heading", Order = 1)]
        public string Heading { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Background Image", Order = 2)]
        public IEnumerable<MediaFilesSelectorItem> ImageUrl { get; set; }
    }
}
