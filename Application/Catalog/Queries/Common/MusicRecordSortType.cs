namespace SimpleMusicStore.Application.Catalog.Queries.Common
{
    using SimpleMusicStore.Domain.Common.Models;

    public class MusicRecordSortType : Enumeration
    {
        public static readonly MusicRecordSortType Popularity = new MusicRecordSortType(1, nameof(Popularity));
        public static readonly MusicRecordSortType DateAdded = new MusicRecordSortType(2, nameof(DateAdded));
        public static readonly MusicRecordSortType DateReleased = new MusicRecordSortType(3, nameof(DateReleased));
        public static readonly MusicRecordSortType Price = new MusicRecordSortType(4, nameof(Price));
        public static readonly MusicRecordSortType SearchQuery = new MusicRecordSortType(4, nameof(SearchQuery));

        private MusicRecordSortType(int value)
            : this(value, FromValue<MusicRecordSortType>(value).Name)
        {
        }

        private MusicRecordSortType(int value, string name)
            : base(value, name)
        {
        }
    }
}
