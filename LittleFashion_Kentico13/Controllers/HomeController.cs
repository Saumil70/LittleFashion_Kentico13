using System;
using System.Threading.Tasks;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using DocumentFormat.OpenXml.Wordprocessing;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using LittleFashion_Kentico13.Controllers;
using LittleFashion_Kentico13.Repository.Home;
using LittleFashion_Kentico13.ViewModel;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterPageRoute(Home.CLASS_NAME, typeof(HomeController))]
namespace LittleFashion_Kentico13.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageDataContextRetriever dataRetriever;
        private readonly IPageAttachmentUrlRetriever pageAttachmentUrlRetriever;
        private readonly HomeRepository homeRepository;

        public HomeController(
            IPageDataContextRetriever dataRetriever,    
            IPageAttachmentUrlRetriever pageAttachmentUrlRetriever,
            HomeRepository homeRepository)
        {
            this.dataRetriever = dataRetriever;
            this.pageAttachmentUrlRetriever = pageAttachmentUrlRetriever;
            this.homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve the current page context as a CarouselItem
            var page = dataRetriever.Retrieve<Home>()?.Page;
            if (page == null)
            {
                return NotFound();
            }

            // Fetch carousel sliders based on the current page's node alias path
            var carouselSliders = await homeRepository.GetCarouselSliders(page.NodeAliasPath);

            // Prepare the ViewModel
            var model = new CarouselBlockViewModel();

            foreach (var slider in carouselSliders)
            {
                var carouselItem = new CarouselItemViewModel()
                {
                    CarouselTitle = slider.Fields.CarouselTitle,
                    CarouselDescription = slider.Fields.CarouselDescription,
                    ButtonText = slider.Fields.ButtonText,
                    ButtonLink = slider.Fields.ButtonLink,
                    CarouselImage = slider.Fields.CarouselImage,
                };
                model.CarouselBlock.Add(carouselItem);
            }

            return View(model);
        }
    }
}