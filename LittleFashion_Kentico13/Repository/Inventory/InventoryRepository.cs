using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.DocumentEngine;
using CMS.Search.Azure;
using LittleFashion_Kentico13.Repository.Search;
using CMS.Search;
using LittleFashion_Kentico13.Models.Search;
using Newtonsoft.Json;
using LittleFashion_Kentico13.ViewModel;

namespace LittleFashion_Kentico13.Repository.Inventory
{
    public class InventoryRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly SearchRepository searchService;


        public InventoryRepository(IPageRetriever pageRetriever, SearchRepository searchService)
        {
            this.pageRetriever = pageRetriever;
            this.searchService = searchService;
        }

        public async Task<IEnumerable<InventoryItemViewModel>> GetNewArrivals()
        {
            string searchText = "New Arrivals";

            // Perform the search
            SearchResultModel searchResult = searchService.PerformSearch(searchText);

            // Initialize a list to store InventoryItemViewModel objects
            var inventoryList = new List<InventoryItemViewModel>();

            foreach (var item in searchResult.Items)
            {
                // Retrieve the Fields property
                var fields = item.Data?.GetType().GetProperty("Fields")?.GetValue(item.Data);

                if (fields != null)
                {
                    var fieldsJson = System.Text.Json.JsonSerializer.Serialize(fields);
                    var inventoryItemViewModel = System.Text.Json.JsonSerializer.Deserialize<InventoryItemViewModel>(fieldsJson);

                    if (inventoryItemViewModel != null)
                    {
                        inventoryList.Add(inventoryItemViewModel);
                    }
                }
            }

            return inventoryList;
        }

        public async Task<IEnumerable<InventoryItemViewModel>> GetPopular()
        {
            string searchText = "Popular";

            // Perform the search
            SearchResultModel searchResult = searchService.PerformSearch(searchText);

            // Initialize a list to store InventoryItemViewModel objects
            var inventoryList = new List<InventoryItemViewModel>();

            foreach (var item in searchResult.Items)
            {
                // Retrieve the Fields property
                var fields = item.Data?.GetType().GetProperty("Fields")?.GetValue(item.Data);

                if (fields != null)
                {
                    var fieldsJson = System.Text.Json.JsonSerializer.Serialize(fields);
                    var inventoryItemViewModel = System.Text.Json.JsonSerializer.Deserialize<InventoryItemViewModel>(fieldsJson);

                    if (inventoryItemViewModel != null)
                    {
                        inventoryList.Add(inventoryItemViewModel);
                    }
                }
            }

            return inventoryList;
        }

        public async Task<InventoryViewModel> GetInventory()
        {
            string searchText = "Inventory";

            // Perform the search
            SearchResultModel searchResult = searchService.PerformSearch(searchText);

            // Initialize a list to store InventoryItemViewModel objects
            var inventory = new InventoryViewModel();

            foreach (var item in searchResult.Items)
            {
                // Retrieve the Fields property
                var fields = item.Data?.GetType().GetProperty("Fields")?.GetValue(item.Data);

                if (fields != null)
                {
                    var fieldsJson = System.Text.Json.JsonSerializer.Serialize(fields);
                    inventory = System.Text.Json.JsonSerializer.Deserialize<InventoryViewModel>(fieldsJson);
                }
            }

            return inventory;
        }
    }
}
