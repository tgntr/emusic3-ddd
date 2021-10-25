namespace SimpleMusicStore.Infrastructure.Common.Persistence
{
    using Domain.Common.Models;
    using Events;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SimpleMusicStore.Domain.Catalog.Models;
    using SimpleMusicStore.Infrastructure.Catalog;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SimpleMusicStoreDbContext : IdentityDbContext<User>, ICatalogDbContext
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly Stack<object> _savesChangesTracker;

        public SimpleMusicStoreDbContext(
            DbContextOptions<SimpleMusicStoreDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            _eventDispatcher = eventDispatcher;
            _savesChangesTracker = new Stack<object>();
        }

        public DbSet<MusicRecord> MusicRecords { get; set; } = default!;
        public DbSet<Artist> Artists { get; set; } = default!;
        public DbSet<Label> Labels { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            _savesChangesTracker.Push(new object());

            var entities = ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await _eventDispatcher.Dispatch(domainEvent);
                }
            }

            _savesChangesTracker.Pop();

            if (!_savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
