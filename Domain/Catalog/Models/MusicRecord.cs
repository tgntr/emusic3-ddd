namespace SimpleMusicStore.Domain.Catalog.Models
{
    using Common;
    using Common.Models;
    using SimpleMusicStore.Domain.Catalog.Events;
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MusicRecord : Entity<int>, IAggregateRoot
    {
        private readonly ICollection<Price> _priceHistory;
        internal MusicRecord(
            int id,
            string title,
            IEnumerable<Artist> artists,
            Label label,
            DateTime dateReleased,
            Genre genre,
            AudioFormat format,
            decimal price,
            IEnumerable<Track> tracklist,
            string imageUrl,
            bool isActive = true)
        {
            ValidateId(id, nameof(Id));
            ValidateString(title, nameof(Title));
            ValidateCollection(artists, nameof(Artists));
            ValidateDate(dateReleased, nameof(DateReleased));
            ValidateCollection(tracklist, nameof(Tracklist));
            ValidateUrl(imageUrl, nameof(ImageUrl));
            _priceHistory = new List<Price>();
            Title = title;
            Artists = artists;
            Label = label;
            DateReleased = dateReleased;
            Genre = genre;
            AudioFormat = format;
            SetPrice(price);
            Tracklist = tracklist;
            ImageUrl = imageUrl;
            IsActive = isActive;
            DateAdded = DateTime.UtcNow;
            RaiseEvent(new NewMusicRecordAddedEvent());
        }

        public string Title { get; }
        public IEnumerable<Artist> Artists { get; }
        public Label Label { get; }
        public DateTime DateReleased { get; }
        public Genre Genre { get; }
        public AudioFormat AudioFormat { get; }
        public decimal Price { get; private set; }
        public IEnumerable<Track> Tracklist { get; }
        public string ImageUrl { get; }
        public bool IsActive { get; private set; }
        public DateTime DateAdded { get; }
        public IReadOnlyCollection<Price> PriceHistory => _priceHistory.ToList().AsReadOnly();
        public int AvailableQuantity { get; private set; }
        public bool IsAvailable => AvailableQuantity > 0;

        public void UpdatePrice(decimal price)
        {
            SetPrice(price);
            RaiseEvent(new MusicRecordPriceUpdatedEvent());
        }

        public void UpdateStatus(bool isActive)
        {
            if (IsActive != isActive)
            {
                IsActive = isActive;
                RaiseEvent(new MusicRecordStatusUpdated());
            }
        }

        private void SetPrice(decimal price)
        {
            ValidatePrice(price, nameof(Price));
            Price = price;
            _priceHistory.Add(new Price(price));
        }

        private void ValidateId(int id, string propertyName)
        {
            Guard.AgainstOutOfRange<InvalidMusicRecordException>(id, CatalogConstants.MIN_INT_VALUE, int.MaxValue, propertyName);
        }

        private void ValidateString(string value, string propertyName)
        {
            Guard.ForStringLength<InvalidMusicRecordException>(value, CatalogConstants.MIN_STRING_LENGTH, CatalogConstants.MAX_STRING_LENGTH, propertyName);
        }

        private void ValidateCollection(IEnumerable<object> collection, string propertyName)
        {
            Guard.AgainstEmptyCollection<InvalidMusicRecordException>(collection, propertyName);
        }

        private void ValidateDate(DateTime dateReleased, string propertyName)
        {
            Guard.AgainstInvalidDate<InvalidMusicRecordException>(dateReleased, CatalogConstants.MIN_DATE_VALUE, DateTime.UtcNow, propertyName);
        }

        private void ValidateUrl(string url, string propertyName)
        {
            Guard.ForValidUrl<InvalidMusicRecordException>(url, propertyName);
        }

        private void ValidatePrice(decimal price, string propertyName)
        {
            Guard.AgainstOutOfRange<InvalidMusicRecordException>(price, CatalogConstants.MIN_INT_VALUE, CatalogConstants.MAX_INT_VALUE, propertyName);
        }
    }
}
