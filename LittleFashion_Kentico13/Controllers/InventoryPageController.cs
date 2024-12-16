using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using LittleFashion_Kentico13.Controllers;
using LittleFashion_Kentico13.Repository.Home;
using LittleFashion_Kentico13.Repository.Inventory;
using LittleFashion_Kentico13.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterPageRoute(Inventory.CLASS_NAME, typeof(InventoryPageController))]

namespace LittleFashion_Kentico13.Controllers
{
    public class InventoryPageController : Controller
    {
        private readonly IPageDataContextRetriever dataRetriever;
        private readonly IPageAttachmentUrlRetriever pageAttachmentUrlRetriever;
        private readonly InventoryRepository inventoryRepository;

        public InventoryPageController(
            IPageDataContextRetriever dataRetriever,
            IPageAttachmentUrlRetriever pageAttachmentUrlRetriever,
            InventoryRepository inventoryRepository)
        {
            this.dataRetriever = dataRetriever;
            this.pageAttachmentUrlRetriever = pageAttachmentUrlRetriever;
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            InventoryViewModel model = await inventoryRepository.GetInventory();
            IEnumerable<InventoryItemViewModel> newArrivals = await inventoryRepository.GetNewArrivals();
            IEnumerable<InventoryItemViewModel> popular = await inventoryRepository.GetPopular();

            model.NewArrivals = newArrivals;
            model.Popular = popular;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByCategory(List<string> categories)
        {
            InventoryViewModel model = await inventoryRepository.GetInventory();

            if (categories != null && categories.Count > 0)
            {
                if (categories.Contains("NewArrivals"))
                {
                    model.NewArrivals = await inventoryRepository.GetNewArrivals();
                }

                if (categories.Contains("Popular"))
                {
                    model.Popular = await inventoryRepository.GetPopular();
                }
            }
            else
            {
                // If no filters are selected, retrieve default data
                model.NewArrivals = await inventoryRepository.GetNewArrivals();
                model.Popular = await inventoryRepository.GetPopular();
            }

            return PartialView("_ProductListings", model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByPrice(int[] pricerange)
        {
            var minValue = pricerange[0];
            var maxValue = pricerange[1];

            InventoryViewModel model = await inventoryRepository.GetInventory();
            IEnumerable<InventoryItemViewModel> newArrivals = await inventoryRepository.GetNewArrivals();
            IEnumerable<InventoryItemViewModel> popular = await inventoryRepository.GetPopular();

            // Filter the New Arrivals based on the price range
            model.NewArrivals = newArrivals.Where(item =>
                !string.IsNullOrEmpty(item.ProductPrice) &&
                int.TryParse(item.ProductPrice.TrimStart('$'), out int price) &&
                price >= minValue &&
                price <= maxValue
            ).ToList();

            // Filter the Popular items based on the price range
            model.Popular = popular.Where(item =>
                !string.IsNullOrEmpty(item.ProductPrice) &&
                int.TryParse(item.ProductPrice.TrimStart('$'), out int price) &&
                price >= minValue &&
                price <= maxValue
            ).ToList();

            return PartialView("_ProductListings", model);
        }
    }
}
