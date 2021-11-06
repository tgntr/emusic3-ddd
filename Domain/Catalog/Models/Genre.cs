namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Genre : ValueObject
    {
        internal Genre(IEnumerable<string> genres, IEnumerable<string> styles)
        {
            ValidateCollection(genres, nameof(Genres));
            ValidateCollection(styles, nameof(Styles));

            Genres = genres.Select(g => g.ToLower());
            Styles = styles.Select(s => s.ToLower());
        }

        public IEnumerable<string> Genres { get; }
        public IEnumerable<string> Styles { get; }

        private void ValidateCollection(IEnumerable<object> collection, string propertyName)
        {
            Guard.AgainstEmptyCollection<InvalidGenreException>(collection, propertyName);
        }
    }
}