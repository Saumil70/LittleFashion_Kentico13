using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.ModalWidget
{
    public class ModalWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Team Member Name", Order = 1)]
        public string TeamMemberName { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Team Member Position", Order = 2)]
        public string TeamMemberPosition { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Description", Order = 3)]
        public string Description { get; set; }

        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Body Content", Order = 4)]
        public string BodyContent { get; set; }

    }
}
