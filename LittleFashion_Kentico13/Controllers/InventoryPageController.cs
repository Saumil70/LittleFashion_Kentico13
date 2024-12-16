using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using LittleFashion_Kentico13.Controllers;
using LittleFashion_Kentico13.Repository.Home;
using LittleFashion_Kentico13.Repository.Inventory;
using LittleFashion_Kentico13.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

    }
}
