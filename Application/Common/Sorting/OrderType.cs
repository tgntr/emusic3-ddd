using SimpleMusicStore.Domain.Common.Models;

namespace SimpleMusicStore.Application.Common.Sorting
{
    public class OrderType : Enumeration
    {
        public static readonly OrderType Ascending = new OrderType(1, nameof(Ascending));
        public static readonly OrderType Descending = new OrderType(2, nameof(Descending));

        private OrderType(int value)
            : this(value, FromValue<OrderType>(value).Name)
        {
        }

        private OrderType(int value, string name)
            : base(value, name)
        {
        }
    }
}