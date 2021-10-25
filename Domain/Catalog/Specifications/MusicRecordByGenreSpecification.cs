namespace SimpleMusicStore.Domain.Catalog.Specifications
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class MusicRecordByGenreSpecification : Specification<MusicRecord>
    {
        private readonly IEnumerable<string>? _genres;
        private readonly IEnumerable<string>? _styles;

        public MusicRecordByGenreSpecification(IEnumerable<string>? genres, IEnumerable<string>? styles)
        {
            _genres = genres?.Select(g => g.ToLower());
            _styles = styles?.Select(s => s.ToLower());
        }

        protected override bool Include =>
            (_genres != null && _genres.Any())
            || (_styles != null && _styles.Any());

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord =>
                musicRecord.Genre.Genres.Any(g => _genres.Contains(g))
                || musicRecord.Genre.Styles.Any(s => _styles.Contains(s));
        }
    }
}