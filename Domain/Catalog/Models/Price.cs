namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Common.Models;
    using System;

    public class Price : ValueObject
    {
        internal Price(decimal value)
        {
            ValidatePrice(value, nameof(Price));
            Value = value;
            DateUpdated = DateTime.UtcNow;
        }

        public decimal Value { get; }
        public DateTime DateUpdated { get; }

        public static implicit operator decimal(Price price) => price.Value;

        public static implicit operator Price(decimal value) => new Price(value);

        private void ValidatePrice(decimal value, string propertyName)
        {
            Guard.AgainstOutOfRange<InvalidPriceException>(value, CatalogConstants.MIN_PRICE, CatalogConstants.MAX_PRICE, propertyName);
        }
    }
}