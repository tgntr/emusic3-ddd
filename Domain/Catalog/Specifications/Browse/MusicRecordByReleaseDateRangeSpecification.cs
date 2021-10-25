namespace SimpleMusicStore.Domain.Catalog.Specifications.Browse
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq.Expressions;

    public class MusicRecordByReleaseDateRangeSpecification : Specification<MusicRecord>
    {
        private readonly DateTime? _minDate;
        private readonly DateTime? _maxDate;

        public MusicRecordByReleaseDateRangeSpecification(DateTime? minDate, DateTime? maxDate)
        {
            _minDate = minDate;
            _maxDate = maxDate;
        }

        protected override bool Include => _minDate != null || _maxDate != null;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord =>
                (_minDate == null || musicRecord.DateReleased >= _minDate)
                && (_maxDate == null || musicRecord.DateReleased <= _maxDate);
        }
    }
}
