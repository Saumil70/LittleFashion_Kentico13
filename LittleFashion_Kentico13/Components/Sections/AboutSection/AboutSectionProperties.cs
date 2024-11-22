using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Sections.AboutSection
{
    /// <summary>
    /// Section properties to define the feature section.
    /// </summary>
    public class AboutSectionProperties : ISectionProperties
    {
        /// <summary>
        /// Title of the section.
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Title", Order = 1)]
        public string AboutSectionTitle { get; set; }
    }
}
