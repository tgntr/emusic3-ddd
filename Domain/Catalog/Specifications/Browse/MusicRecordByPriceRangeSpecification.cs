namespace SimpleMusicStore.Domain.Catalog.Specifications.Browse
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq.Expressions;

    public class MusicRecordByPriceRangeSpecification : Specification<MusicRecord>
    {
        private readonly decimal? _minPrice;
        private readonly decimal? _maxPrice;

        public MusicRecordByPriceRangeSpecification(decimal? minPrice, decimal? maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        protected override bool Include => _minPrice != null || _maxPrice != null;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord =>
                (_minPrice == null || musicRecord.Price >= _minPrice)
                && (_maxPrice == null || musicRecord.Price <= _maxPrice);
        }
    }
}
