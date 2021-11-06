using System;

namespace SimpleMusicStore.Domain.Catalog
{
    public class CatalogConstants
    {
        public const int MIN_STRING_LENGTH = 1;
        public const int MAX_STRING_LENGTH = 50;
        public const int MIN_INT_VALUE = 1;
        public const int MAX_INT_VALUE = 50;
        public const decimal MIN_PRICE = 1;
        public const decimal MAX_PRICE = 50;
        public static DateTime MIN_DATE_VALUE = new DateTime(1950, 1, 1);
        public const StringComparison IGNORE_CASE = StringComparison.InvariantCultureIgnoreCase;
    }
}
