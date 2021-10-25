namespace SimpleMusicStore.Application.Catalog.Queries.Common
{
    using SimpleMusicStore.Application.Catalog.Queries.Search;
    using SimpleMusicStore.Domain.Catalog;
    using System;
    using System.Linq;

    public class SearchCatalogSorter
    {
        private readonly string _searchQuery;

        public SearchCatalogSorter(string searchQuery)
        {
            _searchQuery = searchQuery;
        }

        public Func<SearchCatalogResultOutputModel, object> Sort()
        {
            return searchResult =>
            {
                if (searchResult.Name.StartsWith(_searchQuery, CatalogConstants.IGNORE_CASE))
                    return _searchQuery.Length * 3;
                else if (searchResult.Name.Split().Any(n => n.StartsWith(_searchQuery, CatalogConstants.IGNORE_CASE)))
                    return _searchQuery.Length * 2;
                else if (searchResult.Name.Contains(_searchQuery, CatalogConstants.IGNORE_CASE))
                    //todo check why here 1 and below 2 instead opposite
                    return 1;
                else
                    return 2;
            };
        }
    }
}
