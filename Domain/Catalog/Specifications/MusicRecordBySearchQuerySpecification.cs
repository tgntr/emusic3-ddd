namespace SimpleMusicStore.Domain.Catalog.Specifications

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
              musicRecord.Title.Contains(_searchQuery, StringComparison.InvariantCultureIgnoreCase)
              || musicRecord.Tracklist.Any(t => t.Title.Split().Any(tt => tt.StartsWith(_searchQuery, StringComparison.InvariantCultureIgnoreCase)))
              || musicRecord.Artists.Any(a => a.Name.Contains(_searchQuery, StringComparison.InvariantCultureIgnoreCase)
              || musicRecord.Label.Name.Contains(_searchQuery, StringComparison.InvariantCultureIgnoreCase));
        }

        //todo add sort part
        //private int Match(string name, string searchTerm)
        //{
        //    if (name.StartsWith(searchTerm, StringComparison.InvariantCultureIgnoreCase))
        //        return searchTerm.Length * 3;
        //    else if (name.Split().Any(n => n.StartsWith(searchTerm, StringComparison.InvariantCultureIgnoreCase)))
        //        return searchTerm.Length * 2;
        //    else if (name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
        //        return 1;
        //    else
        //        return 2;
        //}
    }
}
