using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.DocumentEngine;

namespace LittleFashion_Kentico13.Repository.Home
{
    public class HomeRepository
    {
        private readonly IPageRetriever pageRetriever;

        public HomeRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }
        public Task<IEnumerable<CarouselItem>> GetCarouselSliders(string nodeAliasPath)
        {
            return pageRetriever.RetrieveAsync<CarouselItem>(
                query => query
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
               );
        }
    }
}
