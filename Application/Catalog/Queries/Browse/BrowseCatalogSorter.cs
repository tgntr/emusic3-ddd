namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog.Models;
    using SimpleMusicStore.Domain.Common.Models;
    using System;
    using System.Linq.Expressions;

    public class BrowseCatalogSorter : Sorter<MusicRecord, BrowseCatalogSortType>
    {
        public BrowseCatalogSorter(BrowseCatalogSortType? sortBy, OrderType? orderBy)
            : base(
                  sortBy ?? BrowseCatalogSortType.Popularity,
                  orderBy ?? OrderType.Descending)
        {
        }

        public override Expression<Func<MusicRecord, object>> Sort()
        {
            if (SortBy == BrowseCatalogSortType.DateAdded)
            {
                return musicRecord => musicRecord.DateAdded;
            }
            else if (SortBy == BrowseCatalogSortType.DateReleased)
            {
                return musicRecord => musicRecord.DateAdded;
            }
            else if (SortBy == BrowseCatalogSortType.Price)
            {
                return musicRecord => musicRecord.Price;
            }
            else
            {
                return musicRecord => musicRecord.OrderCount;
            }
        }
    }

    public class BrowseCatalogSortType : Enumeration
    {
        public static readonly BrowseCatalogSortType Popularity = new BrowseCatalogSortType(1, nameof(Popularity));
        public static readonly BrowseCatalogSortType DateAdded = new BrowseCatalogSortType(2, nameof(DateAdded));
        public static readonly BrowseCatalogSortType DateReleased = new BrowseCatalogSortType(3, nameof(DateReleased));
        public static readonly BrowseCatalogSortType Price = new BrowseCatalogSortType(4, nameof(Price));
        public static readonly BrowseCatalogSortType SearchQuery = new BrowseCatalogSortType(4, nameof(SearchQuery));

        private BrowseCatalogSortType(int value)
            : this(value, FromValue<BrowseCatalogSortType>(value).Name)
        {
        }

        private BrowseCatalogSortType(int value, string name)
            : base(value, name)
        {
        }
    }
}
