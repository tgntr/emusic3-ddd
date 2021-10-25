namespace SimpleMusicStore.Domain.Catalog.Specifications.Browse

{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class MusicRecordByBrowseSearchQuerySpecification : Specification<MusicRecord>
    {
        private readonly string _searchQuery;

        public MusicRecordByBrowseSearchQuerySpecification(string? searchQuery)
        {
            _searchQuery = searchQuery ?? string.Empty;
        }

        protected override bool Include => !string.IsNullOrEmpty(_searchQuery);

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord =>
                musicRecord.Title.Contains(_searchQuery, CatalogConstants.IGNORE_CASE)
                || musicRecord.Tracklist.Any(t => t.Title.Split().Any(tt => tt.StartsWith(_searchQuery, CatalogConstants.IGNORE_CASE)))
                || musicRecord.Artists.Any(a => a.Name.Contains(_searchQuery, CatalogConstants.IGNORE_CASE)
                || musicRecord.Label.Name.Contains(_searchQuery, CatalogConstants.IGNORE_CASE));
        }
    }
}
