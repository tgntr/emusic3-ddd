namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Common.Models;

    public class Label : Entity<int>
    {
        internal Label(int id, string name, string imageUrl)
        {
            ValidateId(id, nameof(Id));
            ValidateString(name, nameof(Name));
            ValidateUrl(imageUrl, nameof(ImageUrl));
            Name = name;
            ImageUrl = imageUrl;
        }

        public string Name { get; }
        public string ImageUrl { get; }

        private void ValidateId(int id, string propertyName)
        {
            Guard.AgainstOutOfRange<InvalidLabelException>(id, CatalogConstants.MIN_INT_VALUE, int.MaxValue, propertyName);
        }

        private void ValidateString(string value, string propertyName)
        {
            Guard.ForStringLength<InvalidLabelException>(value, CatalogConstants.MIN_STRING_LENGTH, CatalogConstants.MAX_STRING_LENGTH, propertyName);
        }

        private void ValidateUrl(string url, string propertyName)
        {
            Guard.ForValidUrl<InvalidLabelException>(url, propertyName);
        }
    }
}