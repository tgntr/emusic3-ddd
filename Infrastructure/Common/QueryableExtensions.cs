namespace SimpleMusicStore.Infrastructure.Common
{
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Common;
    using SimpleMusicStore.Domain.Common.Models;
    using System.Linq;

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Sort<TEntity, TSortType>(
            this IQueryable<TEntity> queryable,
            Sorter<TEntity, TSortType> sorter)
        where TEntity : IAggregateRoot
        where TSortType : Enumeration
        {
            if (sorter.OrderBy == OrderType.Descending)
            {
                return queryable.OrderByDescending(sorter.Sort());
            }
            else
            {
                return queryable.OrderBy(sorter.Sort());
            }
        }
    }
}
