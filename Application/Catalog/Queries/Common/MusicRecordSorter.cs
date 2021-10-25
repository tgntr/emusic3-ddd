namespace SimpleMusicStore.Application.Catalog.Queries.Common
{
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class MusicRecordSorter : Sorter<MusicRecord, MusicRecordSortType>
    {
        private readonly string _searchQuery;

        public MusicRecordSorter(MusicRecordSortType? sortBy, OrderType? orderBy, string? searchQuery)
            : base(
                  sortBy ?? MusicRecordSortType.Popularity,
                  orderBy ?? OrderType.Descending)
        {
            _searchQuery = searchQuery ?? string.Empty;
        }

        public override Expression<Func<MusicRecord, object>> Sort()
        {
            if (SortBy == MusicRecordSortType.DateAdded)
            {
                return musicRecord => musicRecord.DateAdded;
            }
            else if (SortBy == MusicRecordSortType.DateReleased)
            {
                return musicRecord => musicRecord.DateAdded;
            }
            else if (SortBy == MusicRecordSortType.Price)
            {
                return musicRecord => musicRecord.Price;
            }
            else if (SortBy == MusicRecordSortType.SearchQuery)
            {
                return musicRecord => SortBySearchQuery(musicRecord.Title, _searchQuery);
            }
            else
            {
                return musicRecord => musicRecord.OrderCount;
            }
        }

        private int SortBySearchQuery(string recordName, string searchQuery)
        {
            if (recordName.StartsWith(searchQuery, StringComparison.InvariantCultureIgnoreCase))
                return searchQuery.Length * 3;
            else if (recordName.Split().Any(n => n.StartsWith(searchQuery, StringComparison.InvariantCultureIgnoreCase)))
                return searchQuery.Length * 2;
            else if (recordName.Contains(searchQuery, StringComparison.InvariantCultureIgnoreCase))
                //todo check why here 1 and below 2 instead opposite
                return 1;
            else
                return 2;
        }
    }
}
