namespace SimpleMusicStore.Application.Catalog
{
    using Common.Contracts;
    using SimpleMusicStore.Application.Catalog.Queries.Common;
    using SimpleMusicStore.Domain.Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using SimpleMusicStore.Application.Catalog.Queries.Search;

    public interface ICatalogQueryRepository : IQueryRepository<MusicRecord>
    {
        Task<object> GetDetails(int id, CancellationToken cancellationToken = default);
        Task<object> GetBrowsingOptions(CancellationToken cancellationToken = default);
        Task<IEnumerable<SearchCatalogMusicRecordOutputModel>> Search(
                Specification<MusicRecord> filterBy,
                MusicRecordSorter sortBy,
                int page,
                CancellationToken cancellationToken = default);
    }
}
