using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Sections.FAQsSection
{
    /// <summary>
    /// Section properties to define the feature section.
    /// </summary>
    public class FAQsSectionProperties : ISectionProperties
    {
        /// <summary>
        /// Title of the section.
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "General FAQs Title", Order = 1)]
        public string GeneralFAQsTitle { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Product FAQs Title", Order = 2)]
        public string ProductFAQsTitle { get; set; }
    }
}
