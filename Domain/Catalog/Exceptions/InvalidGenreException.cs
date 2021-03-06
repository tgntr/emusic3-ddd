namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using SimpleMusicStore.Domain.Common;

    public class InvalidGenreException : BaseDomainException
    {
        public InvalidGenreException()
        {
        }

        public InvalidGenreException(string error) => this.Error = error;
    }
}