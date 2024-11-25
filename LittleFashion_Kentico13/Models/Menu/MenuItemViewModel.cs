using System.Collections.Generic;

namespace LittleFashion_Kentico13.Models.Menu
{
    public class MenuItemViewModel
    {
        public string MenuItemText { get; set; }
        public string MenuItemRelativeUrl { get; set; }
    }

    public class HeaderViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; }
        public string SiteName { get; set; }
        public string CurrentPageUrl { get; set; }
    }
}
