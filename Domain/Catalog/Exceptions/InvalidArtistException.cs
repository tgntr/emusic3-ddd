namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;

    public class InvalidArtistException : BaseDomainException
    {
        public InvalidArtistException()
        {
        }

        public InvalidArtistException(string error) => this.Error = error;
    }
}