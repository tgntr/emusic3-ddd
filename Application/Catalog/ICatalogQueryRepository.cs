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
    using SimpleMusicStore.Application.Catalog.Queries.Search;

    public interface ICatalogQueryRepository : IQueryRepository<MusicRecord>
    {
        Task<object> GetMusicRecordDetails(int id, CancellationToken cancellationToken = default);

        Task<object> GetBrowsingOptions(CancellationToken cancellationToken = default);

        Task<IEnumerable<BrowseCatalogMusicRecordOutputModel>> BrowseMusicRecords(
                Specification<MusicRecord> filterBy,
                BrowseCatalogSorter sortBy,
                int page,
                CancellationToken cancellationToken = default);

        Task<IEnumerable<SearchCatalogResultOutputModel>> SearchMusicRecords(
                MusicRecordBySearchQuerySpecification searchQuery,
                CancellationToken cancellationToken = default);

        Task<IEnumerable<SearchCatalogResultOutputModel>> SearchArtists(
                ArtistLabelBySearchQuerySpecification searchQuery,
                CancellationToken cancellationToken = default);

        Task<IEnumerable<SearchCatalogResultOutputModel>> SearchLabels(
                ArtistLabelBySearchQuerySpecification searchQuery,
                CancellationToken cancellationToken = default);
    }
}
