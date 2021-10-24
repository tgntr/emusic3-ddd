namespace SimpleMusicStore.Domain.Catalog.Specifications
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq.Expressions;

    public class MusicRecordByLabelSpecification : Specification<MusicRecord>
    {
        private readonly int? _labelId;

        public MusicRecordByLabelSpecification(int? labelId)
        {
            _labelId = labelId;
        }

        protected override bool Include => _labelId != null;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord => musicRecord.Label.Id == _labelId;
        }
    }
}
