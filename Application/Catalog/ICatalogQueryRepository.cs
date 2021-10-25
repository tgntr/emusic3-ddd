namespace SimpleMusicStore.Application.Catalog
{
    using Common.Contracts;
    using SimpleMusicStore.Application.Catalog.Queries.Common;
    using SimpleMusicStore.Domain.Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using SimpleMusicStore.Application.Catalog.Queries.Browse;
    using SimpleMusicStore.Domain.Catalog.Specifications;
    using SimpleMusicStore.Domain.Catalog.Specifications.Search;

    public interface ICatalogQueryRepository : IQueryRepository<MusicRecord>
    {
        Task<object> GetMusicRecordDetails(int id, CancellationToken cancellationToken = default);

        Task<object> GetBrowsingOptions(CancellationToken cancellationToken = default);

        Task<IEnumerable<BrowseCatalogMusicRecordOutputModel>> BrowseMusicRecords(
                Specification<MusicRecord> filterBy,
                MusicRecordSorter sortBy,
                int page,
                CancellationToken cancellationToken = default);

        Task<IEnumerable<object>> SearchMusicRecords(
                MusicRecordBySearchQuerySpecification searchQuery,
                int page,
                CancellationToken cancellationToken = default);
    }
}
