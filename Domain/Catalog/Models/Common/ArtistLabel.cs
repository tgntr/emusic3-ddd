using SimpleMusicStore.Domain.Catalog.Exceptions.Common;
using SimpleMusicStore.Domain.Common;
using SimpleMusicStore.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Domain.Catalog.Models.Common
{
    public abstract class ArtistLabel<TException> : ValueObject
        where TException : ArtistLabelException, new()
    {
        protected ArtistLabel(int id, string name, string imageUrl)
        {
            ValidateId(id, nameof(Id));
            ValidateString(name, nameof(Name));
            ValidateUrl(imageUrl, nameof(ImageUrl));
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string Name { get; } = default!;
        public string ImageUrl { get; } = default!;

        private void ValidateId(int id, string propertyName)
        {
            Guard.AgainstOutOfRange<TException>(id, CatalogConstants.MIN_INT_VALUE, int.MaxValue, propertyName);
        }

        private void ValidateString(string value, string propertyName)
        {
            Guard.ForStringLength<TException>(value, CatalogConstants.MIN_STRING_LENGTH, CatalogConstants.MAX_STRING_LENGTH, propertyName);
        }

        private void ValidateUrl(string url, string propertyName)
        {
            Guard.ForValidUrl<TException>(url, propertyName);
        }
    }
}
