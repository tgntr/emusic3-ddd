namespace SimpleMusicStore.Domain.Catalog.Specifications
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class MusicRecordByArtistSpecification : Specification<MusicRecord>
    {
        private readonly int? _artistId;

        public MusicRecordByArtistSpecification(int? artistId)
        {
            _artistId = artistId;
        }

        protected override bool Include => _artistId != null;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord => musicRecord.Artists.Any(a => a.Id == _artistId);
        }
    }
}
