using SimpleMusicStore.Domain.Catalog.Exceptions;
using SimpleMusicStore.Domain.Common.Models;

namespace SimpleMusicStore.Domain.Catalog.Models
{
    public class Track : ValueObject
    {
        internal Track(string title, string? duration, string? audioUrl)
        {
            ValidateString(title, nameof(Title));
            ValidateUrl(audioUrl, nameof(AudioUrl));
            Title = title;
            Duration = duration ?? default!;
            AudioUrl = audioUrl ?? default!;
        }

        public string Title { get; }
        public string Duration { get; }
        public string AudioUrl { get; }

        private void ValidateString(string value, string propertyName)
        {
            Guard.ForStringLength<InvalidTrackException>(value, CatalogConstants.MIN_STRING_LENGTH, CatalogConstants.MAX_STRING_LENGTH, propertyName);
        }

        private void ValidateUrl(string? url, string propertyName)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Guard.ForValidUrl<InvalidTrackException>(url, propertyName);
            }
        }
    }
}