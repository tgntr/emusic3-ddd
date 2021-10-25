namespace SimpleMusicStore.Domain.Catalog.Specifications.Browse
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq.Expressions;

    public class MusicRecordOnlyAvailableSpecification : Specification<MusicRecord>
    {
        private readonly bool _onlyAvailable;

        public MusicRecordOnlyAvailableSpecification(bool? onlyAvailable)
        {
            _onlyAvailable = onlyAvailable ?? true;
        }

        protected override bool Include => _onlyAvailable == true;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord => musicRecord.IsActive && musicRecord.IsAvailable;
        }
    }
}
