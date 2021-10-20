namespace SimpleMusicStore.Domain.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static class Guard
    {
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void AgainstEmptyCollection<TException>(IEnumerable<object> collection, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (collection != null && collection.Any())
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        public static void AgainstInvalidDate<TException>(DateTime date, DateTime dateMin, DateTime dateMax, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (date != null && dateMin != null && dateMax != null && date >= dateMin && date <= dateMax)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {dateMin.ToShortDateString()} and {dateMax.ToShortDateString()}.");
        }

        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        public static void ForValidEmail<TException>(string email, string name = "Value")
            where TException : BaseDomainException, new()
        {
            var emailValidator = new EmailAddressAttribute();
            if (emailValidator.IsValid(email))
                return;

            ThrowException<TException>($"{name} must be a valid email.");
        }

        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
