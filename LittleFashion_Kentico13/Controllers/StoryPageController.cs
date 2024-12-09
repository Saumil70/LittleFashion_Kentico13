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

[assembly: RegisterPageRoute(StoryPage.CLASS_NAME, typeof(StoryPageController))]
namespace LittleFashion_Kentico13.Controllers
{
    public class StoryPageController : Controller
    {
        private readonly IPageDataContextRetriever dataRetriever;
        private readonly IPageAttachmentUrlRetriever pageAttachmentUrlRetriever;

        public StoryPageController(
            IPageDataContextRetriever dataRetriever,    
            IPageAttachmentUrlRetriever pageAttachmentUrlRetriever)
        {
            this.dataRetriever = dataRetriever;
            this.pageAttachmentUrlRetriever = pageAttachmentUrlRetriever;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}