namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;

    public class InvalidGenreException : BaseDomainException
    {
        public InvalidGenreException()
        {
        }

        public InvalidGenreException(string error) => this.Error = error;
    }
}