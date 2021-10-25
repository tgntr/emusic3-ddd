namespace SimpleMusicStore.Application.Catalog.Queries.Common
{
    using SimpleMusicStore.Application.Catalog.Queries.Search;
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class SearchCatalogSorterHelpers
    {
        public static IEnumerable<SearchCatalogOutputModel> SortSearchResults(
            this IEnumerable<SearchCatalogOutputModel> results,
            string searchQuery)
        {
            return results.OrderByDescending(SearchQueryMatch(searchQuery));
        }
        private static Func<SearchCatalogOutputModel, object> SearchQueryMatch(string searchQuery)
        {
            return searchResult =>
            {
                if (searchResult.Name.StartsWith(searchQuery, CatalogConstants.IGNORE_CASE))
                    return searchQuery.Length * 3;
                else if (searchResult.Name.Split().Any(n => n.StartsWith(searchQuery, CatalogConstants.IGNORE_CASE)))
                    return searchQuery.Length * 2;
                else if (searchResult.Name.Contains(searchQuery, CatalogConstants.IGNORE_CASE))
                    //todo check why here 1 and below 2 instead opposite
                    return 1;
                else
                    return 2;
            };
        }
    }
}
