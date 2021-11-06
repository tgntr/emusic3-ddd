namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using SimpleMusicStore.Domain.Common;

    public class InvalidStockException : BaseDomainException
    {
        public InvalidStockException()
        {
        }

        public InvalidStockException(string error) => this.Error = error;
    }
}