namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;

    public class InvalidArtistException : InvalidArtistLabelException
    {
        public InvalidArtistException()
        {
        }

        public InvalidArtistException(string error) => this.Error = error;
    }
}