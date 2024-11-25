using System.Collections.Generic;

namespace LittleFashion_Kentico13.ViewModel.Menu
{
    public class HeaderViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; }
        public string SiteName { get; set; }
        public string CurrentPageUrl { get; set; }
    }

    public class MenuItemViewModel
    {
        public string MenuItemText { get; set; }
        public string MenuItemRelativeUrl { get; set; }
    }


}
