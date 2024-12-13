using LittleFashion_Kentico13.Models.Search;
using LittleFashion_Kentico13.Repository.Search;
using Microsoft.AspNetCore.Mvc;

namespace LittleFashion_Kentico13.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchRepository searchService;

        public SearchController(SearchRepository searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public ActionResult SearchIndex(string searchText)
        {
            var model = searchService.PerformSearch(searchText);
            return View(model);
        }
    }
}
