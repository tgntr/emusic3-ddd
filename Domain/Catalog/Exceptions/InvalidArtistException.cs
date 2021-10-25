namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;
    using SimpleMusicStore.Domain.Common;

    public class InvalidArtistException : ArtistLabelException
    {
        public InvalidArtistException()
        {
        }

        public InvalidArtistException(string error) => this.Error = error;
    }
}