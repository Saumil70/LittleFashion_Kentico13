using DocumentFormat.OpenXml.Office2010.ExcelAc;
using LittleFashion_Kentico13.ViewModel.Menu;
using org.pdfclown.documents.interaction.annotations;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.ViewModel.Footer
{
    public class FooterViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; }
        public string SiteName { get; set; }
        public string CopyRightText { get; set; }
        public string SitemapText { get; set; }
        public string SocialText { get; set; }
        public List<SocialLinksViewModel> SocialLinks { get; set; }
    }

    public class SocialLinksViewModel
    {
        public string SocialLinkText { get; set; }
        public string SocialLink { get; set; }
    }

    public class MenuItemViewModel
    {
        public string MenuItemText { get; set; }
        public string MenuItemRelativeUrl { get; set; }
    }
}
