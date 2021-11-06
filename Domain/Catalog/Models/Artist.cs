namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Catalog.Models.Common;

    public class Artist : ArtistLabel<InvalidArtistException>
    {
        internal Artist(int id, string name, string imageUrl)
            : base(id, name, imageUrl)
        {
        }
    }
}