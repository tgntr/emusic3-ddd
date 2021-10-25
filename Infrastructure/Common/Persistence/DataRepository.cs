namespace SimpleMusicStore.Infrastructure.Common.Persistence
{
    using Domain.Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected readonly TDbContext _dbContext;
        protected readonly IQueryable<TEntity> _dbSet;

        protected DataRepository(TDbContext db)
        {
            _dbContext = db;
            _dbSet = db.Set<TEntity>();
        }

        public Task Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}