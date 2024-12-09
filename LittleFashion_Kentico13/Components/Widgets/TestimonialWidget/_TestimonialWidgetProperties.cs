using DocumentFormat.OpenXml.Spreadsheet;
using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.TestimonialWidget
{
    public class _TestimonialWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Team Member Name", Order = 1)]
        public string TeamMemberName { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Testimonial Message", Order = 2)]
        public string TestimonialMessage { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Background Image", Order = 3)]
        public IEnumerable<MediaFilesSelectorItem> ImageUrl { get; set; }
    }
}
