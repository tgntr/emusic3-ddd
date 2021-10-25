namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using SimpleMusicStore.Domain.Common;

    public class InvalidMusicRecordException : BaseDomainException
    {
        public InvalidMusicRecordException()
        {
        }

        public InvalidMusicRecordException(string error) => this.Error = error;
    }
}