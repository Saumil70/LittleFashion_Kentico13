using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Sections.ProductSection
{
    /// <summary>
    /// Section properties to define the feature section.
    /// </summary>
    public class ProductSectionProperties : ISectionProperties
    {
        /// <summary>
        /// Title of the section.
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "First Title", Order = 1)]
        public string FirstTitle { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Second Title", Order = 2)]
        public string SecondTitle { get; set; }
    }
}
