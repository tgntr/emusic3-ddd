namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;
    using SimpleMusicStore.Domain.Common;

    public class InvalidPriceException : BaseDomainException
    {
        public InvalidPriceException()
        {
        }

        public InvalidPriceException(string error) => this.Error = error;
    }
}