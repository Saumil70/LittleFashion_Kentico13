﻿using System.Collections.Generic;

namespace LittleFashion_Kentico13.ViewModel
{
    public class InventoryViewModel
    {
        public string FirstTitle { get; set; }
        public string SecondTitle { get; set; }
        public IEnumerable<InventoryItemViewModel> NewArrivals { get; set; } = new List<InventoryItemViewModel>();
        public IEnumerable<InventoryItemViewModel> Popular { get; set; } = new List<InventoryItemViewModel>();

    }
}
