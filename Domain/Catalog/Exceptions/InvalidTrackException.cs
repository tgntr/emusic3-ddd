﻿namespace SimpleMusicStore.Domain.Catalog.Exceptions
{
    using Common;

    public class InvalidTrackException : BaseDomainException
    {
        public InvalidTrackException()
        {
        }

        public InvalidTrackException(string error) => this.Error = error;
    }
}