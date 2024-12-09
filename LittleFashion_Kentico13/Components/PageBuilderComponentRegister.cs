using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using LittleFashion_Kentico13;
using LittleFashion_Kentico13.Components.Sections;



// Sections
[assembly: RegisterSection(ComponentIdentifiers.SINGLE_COLUMN_SECTION, "1 column", typeof(ThemeSectionProperties), "~/Components/Sections/_LittleFashion_Kentico13_SingleColumnSection.cshtml", Description = "Single-column section with one full-width zone.", IconClass = "icon-square")]
[assembly: RegisterSection(ComponentIdentifiers.THREE_COLUMN_SECTION, "3 column", typeof(ThemeSectionProperties), "~/Components/Sections/_LittleFashion_Kentico13_ThreeColumnSection.cshtml", Description = "Three-column section", IconClass = "icon-square")]
[assembly: RegisterSection(ComponentIdentifiers.TESTIMONIAL_SECTION, "Testimonial Section", typeof(ThemeSectionProperties), "~/Components/Sections/TestimonialSection/TestimonialSection.cshtml", Description = "Testimonial Section", IconClass = "icon-square")]