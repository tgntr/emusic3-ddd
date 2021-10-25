namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;
    using SimpleMusicStore.Domain.Common;

    public class InvalidStockException : BaseDomainException
    {
        public InvalidStockException()
        {
        }

        public InvalidStockException(string error) => this.Error = error;
    }
}