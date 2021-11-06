namespace SimpleMusicStore.Domain.Catalog.Specifications.Search

{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class MusicRecordBySearchQuerySpecification : Specification<MusicRecord>
    {
        private readonly string _searchQuery;

        public MusicRecordBySearchQuerySpecification(string? searchQuery)
        {
            _searchQuery = searchQuery ?? string.Empty;
        }

        protected override bool Include => !string.IsNullOrEmpty(_searchQuery);

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord =>
                musicRecord.Title.Contains(_searchQuery, CatalogConstants.IGNORE_CASE)
                || musicRecord.Tracklist.Any(t => t.Title.Split().Any(tt => tt.StartsWith(_searchQuery, CatalogConstants.IGNORE_CASE)));
        }
    }
}
