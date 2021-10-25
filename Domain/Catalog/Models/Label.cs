namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using SimpleMusicStore.Domain.Catalog.Models.Common;

    public class Label : ArtistLabel<InvalidLabelException>
    {
        internal Label(int id, string name, string imageUrl)
            : base(id, name, imageUrl)
        {
        }
    }
}