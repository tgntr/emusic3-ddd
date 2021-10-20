namespace SimpleMusicStore.Application.Common.Sorting
{
    using SimpleMusicStore.Domain.Common;
    using SimpleMusicStore.Domain.Common.Models;
    using System;
    using System.Linq.Expressions;

    public abstract class Sorter<TEntity, TSortType>
        where TEntity : IAggregateRoot
        where TSortType : Enumeration
    {
        protected Sorter(TSortType sortBy, OrderType orderBy)
        {
            this.SortBy = sortBy;
            this.OrderBy = orderBy;
        }

        public TSortType SortBy { get; protected set; }

        public OrderType OrderBy { get; protected set; }

        public abstract Expression<Func<TEntity, object>> Sort();
    }
}