namespace SimpleMusicStore.Application.Catalog.Queries.Search
{
    using MediatR;
    using SimpleMusicStore.Application.Common.Pagination;
    using SimpleMusicStore.Domain.Catalog.Specifications.Search;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchCatalogQuery : PagedQuery, IRequest<IEnumerable<SearchCatalogResultOutputModel>>
    {
        public string SearchQuery { get; set; } = default!;
        public MusicRecordBySearchQuerySpecification MusicRecordSpecification
            => new MusicRecordBySearchQuerySpecification(SearchQuery);
        public ArtistLabelBySearchQuerySpecification ArtistLabelSpecification
            => new ArtistLabelBySearchQuerySpecification(SearchQuery);
        public SearchCatalogSorter Sorter
            => new SearchCatalogSorter(SearchQuery);

        public class SearchCatalogQueryHandler : IRequestHandler<SearchCatalogQuery, IEnumerable<SearchCatalogResultOutputModel>>
        {
            private readonly ICatalogQueryRepository _inventoryQueryRepository;

            public SearchCatalogQueryHandler(
                ICatalogQueryRepository inventoryQueryRepository)
            {
                _inventoryQueryRepository = inventoryQueryRepository;
            }

            public async Task<IEnumerable<SearchCatalogResultOutputModel>> Handle(
                SearchCatalogQuery request,
                CancellationToken cancellationToken)
            {
                var musicRecords = _inventoryQueryRepository.SearchMusicRecords(request.MusicRecordSpecification, cancellationToken);
                var artists = _inventoryQueryRepository.SearchArtists(request.ArtistLabelSpecification, cancellationToken);
                var labels = _inventoryQueryRepository.SearchLabels(request.ArtistLabelSpecification, cancellationToken);
                //todo verify this is good approach
                await Task.WhenAll(musicRecords, artists, labels);

                //todo paging and cache
                return new HashSet<SearchCatalogResultOutputModel>()
                    .Concat(await musicRecords)
                    .Concat(await artists)
                    .Concat(await labels)
                    .OrderByDescending(request.Sorter.Sort())
                    .Take(10);
            }
        }
    }
}
