using System.Collections.Generic;
using CMS.Search;

namespace LittleFashion_Kentico13.Models.Search
{
    public class SearchResultModel
    {
        public string Query { get; set; }

        public IEnumerable<SearchResultItem> Items { get; set; }
    }
}
