namespace SimpleMusicStore.Domain.Catalog.Specifications.Search

{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Exceptions.Common;
    using SimpleMusicStore.Domain.Catalog.Models.Common;
    using System;
    using System.Linq.Expressions;

    public class ArtistLabelBySearchQuerySpecification : Specification<ArtistLabel<ArtistLabelException>>
    {
        private readonly string _searchQuery;

        public ArtistLabelBySearchQuerySpecification(string? searchQuery)
        {
            _searchQuery = searchQuery ?? string.Empty;
        }

        protected override bool Include => !string.IsNullOrEmpty(_searchQuery);

        public override Expression<Func<ArtistLabel<ArtistLabelException>, bool>> Filter()
        {
            return artistLabel => artistLabel.Name.Contains(_searchQuery, CatalogConstants.IGNORE_CASE);

        }
    }
}
