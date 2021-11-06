namespace SimpleMusicStore.Domain.Catalog.Repositories
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICatalogDomainRepository : IDomainRepository<MusicRecord>
    {
        Task<MusicRecord> FindMusicRecord(int id, CancellationToken cancellationToken = default);
        Task<bool> IsExistingMusicRecord(int id, CancellationToken cancellationToken = default);
    }
}