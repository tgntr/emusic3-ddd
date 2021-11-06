namespace SimpleMusicStore.Domain.Catalog.Models
{
    using SimpleMusicStore.Domain.Common.Models;

    public class AudioFormat : Enumeration
    {
        public static readonly AudioFormat Vinyl = new AudioFormat(1, nameof(Vinyl));
        public static readonly AudioFormat Cd = new AudioFormat(2, nameof(Cd));

        private AudioFormat(int value)
            : this(value, FromValue<AudioFormat>(value).Name)
        {
        }

        private AudioFormat(int value, string name)
            : base(value, name)
        {
        }
    }
}