using CMS.Membership;
using CMS.Search;
using LittleFashion_Kentico13.Models.Search;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Repository.Search
{
    public class SearchRepository
    {
        private const int PAGE_SIZE = 10;
        private readonly string[] searchIndexes = new string[] { "LittleFashion-Pages" };

        public SearchResultModel PerformSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return new SearchResultModel
                {
                    Items = new List<SearchResultItem>(),
                    Query = string.Empty
                };
            }

            SearchParameters searchParameters = SearchParameters.PrepareForPages(searchText, searchIndexes, 1, PAGE_SIZE, MembershipContext.AuthenticatedUser, "en-us", true);
            SearchResult searchResult = SearchHelper.Search(searchParameters);

            return new SearchResultModel
            {
                Items = searchResult.Items,
                Query = searchText
            };
        }
    }
}
