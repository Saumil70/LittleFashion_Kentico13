using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.DocumentEngine;

namespace LittleFashion_Kentico13.Repository.Inventory
{
    public class InventoryRepository
    {
        private readonly IPageRetriever pageRetriever;

        public InventoryRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }
        public Task<IEnumerable<InventoryItem>> GetNewArrivals(string nodeAliasPath)
        {
            return pageRetriever.RetrieveAsync<InventoryItem>(
                query => query
                    .Path($"{nodeAliasPath}/New-Arrivals", PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
               );
        }

        public Task<IEnumerable<InventoryItem>> GetPopular(string nodeAliasPath)
        {
            return pageRetriever.RetrieveAsync<InventoryItem>(
                query => query
                    .Path($"{nodeAliasPath}/Popular", PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
               );
        }
    }
}
