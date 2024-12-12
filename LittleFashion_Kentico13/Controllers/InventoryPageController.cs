using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using LittleFashion_Kentico13.Controllers;
using LittleFashion_Kentico13.Repository.Home;
using LittleFashion_Kentico13.Repository.Inventory;
using LittleFashion_Kentico13.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
            var newArrivals = await inventoryRepository.GetNewArrivals(page.NodeAliasPath);
            var popular = await inventoryRepository.GetPopular(page.NodeAliasPath);

            // Prepare the ViewModel
            var model = new InventoryViewModel();

            model.FirstTitle = page.FirstTitle;
            model.SecondTitle = page.SecondTitle;

            foreach (var newArrivalItem in newArrivals)
            {
                InventoryItemViewModel inventoryItemViewModel = new InventoryItemViewModel()
                {
                    ProductName = newArrivalItem.ProductName,
                    ProductDescription = newArrivalItem.ProductDescription,
                    ProductPrice = newArrivalItem.ProductPrice,
                    ProductUrl = newArrivalItem.ProductUrl,
                    ProductStatus = newArrivalItem.ProductStatus,
                    ImageUrl = newArrivalItem.ImageUrl,
                };
                model.NewArrivals.Add(inventoryItemViewModel);
            }

            foreach (var popularItem in popular)
            {
                InventoryItemViewModel popularItemViewModel = new InventoryItemViewModel()
                {
                    ProductName = popularItem.ProductName,
                    ProductDescription = popularItem.ProductDescription,
                    ProductPrice = popularItem.ProductPrice,
                    ProductUrl = popularItem.ProductUrl,
                    ProductStatus = popularItem.ProductStatus,
                    ImageUrl = popularItem.ImageUrl,
                };
                model.Popular.Add(popularItemViewModel);
            }
            return View(model);
        }
    }
}
