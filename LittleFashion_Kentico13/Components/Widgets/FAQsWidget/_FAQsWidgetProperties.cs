using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.FAQsWidget
{
    public class _FAQsWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Question", Order = 1)]
        public string Question { get; set; }

        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Answer", Order = 2)]
        public string Answer { get; set; }
    }
}
