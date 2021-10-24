namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Common.Models;
    using System;

    public class Price : ValueObject
    {
        internal Price(decimal price)
        {
            ValidatePrice(price, nameof(Price));

            Value = price;
            DateUpdated = DateTime.UtcNow;
        }

        public decimal Value { get; }
        public DateTime DateUpdated { get; }

        private void ValidatePrice(decimal price, string propertyName)
        {
            Guard.AgainstOutOfRange<InvalidPriceException>(price, CatalogConstants.MIN_INT_VALUE, CatalogConstants.MAX_INT_VALUE, propertyName);
        }
    }
}