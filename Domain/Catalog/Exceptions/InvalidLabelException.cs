namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;

    public class InvalidLabelException : BaseDomainException
    {
        public InvalidLabelException()
        {
        }

        public InvalidLabelException(string error) => this.Error = error;
    }
}