namespace SimpleMusicStore.Infrastructure.Common
{
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Common;
    using SimpleMusicStore.Domain.Common.Models;
    using System.Linq;

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Sort<TEntity, TSortType>(
            this IQueryable<TEntity> query,
            Sorter<TEntity, TSortType> sorter
        )
            where TEntity : IAggregateRoot
            where TSortType : Enumeration
        {
            if (sorter.OrderBy == OrderType.Descending)
            {
                return query.OrderByDescending(sorter.Sort());
            }
            else
            {
                return query.OrderBy(sorter.Sort());
            }
        }

        public static IQueryable<TEntity> ToPage<TEntity>(this IQueryable<TEntity> query, int page)
        {
            const int PAGE_SIZE = 24;

            var skip = (page - 1) * PAGE_SIZE;

            return query.Skip(skip).Take(PAGE_SIZE);
        }
    }
}
