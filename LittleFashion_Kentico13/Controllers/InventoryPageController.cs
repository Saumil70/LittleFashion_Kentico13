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
            // Retrieve the current page context as a CarouselItem
            var page = dataRetriever.Retrieve<Inventory>()?.Page;
            if (page == null)
            {
                return NotFound();
            }

            // Fetch carousel sliders based on the current page's node alias path
            InventoryViewModel model = await inventoryRepository.GetInventory();
            IEnumerable<InventoryItemViewModel> newArrivals = await inventoryRepository.GetNewArrivals();
            IEnumerable<InventoryItemViewModel> popular = await inventoryRepository.GetPopular();

            model.NewArrivals = newArrivals;
            model.Popular = popular;

            return View(model);
        }
    }
}
