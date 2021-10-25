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
        //todo check if response should be Result when Validator is available
        public string SearchQuery { get; set; } = default!;

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
                var musicRecords = _inventoryQueryRepository.SearchMusicRecords(GetSearchMusicRecordSpecification(request), cancellationToken);
                var artists = _inventoryQueryRepository.SearchArtists(GetSearchArtistLabelSpecification(request), cancellationToken);
                var labels = _inventoryQueryRepository.SearchLabels(GetSearchArtistLabelSpecification(request), cancellationToken);
                //todo verify this is good approach
                await Task.WhenAll(musicRecords, artists, labels);

                //todo paging and cache
                return new HashSet<SearchCatalogResultOutputModel>()
                    .Concat(await musicRecords)
                    .Concat(await artists)
                    .Concat(await labels)
                    .OrderByDescending(GetSearchSorter(request).Sort())
                    .Take(10);
            }

            private MusicRecordBySearchQuerySpecification GetSearchMusicRecordSpecification(SearchCatalogQuery request)
                => new MusicRecordBySearchQuerySpecification(request.SearchQuery);

            private ArtistLabelBySearchQuerySpecification GetSearchArtistLabelSpecification(SearchCatalogQuery request)
                => new ArtistLabelBySearchQuerySpecification(request.SearchQuery);

            public SearchCatalogSorter GetSearchSorter(SearchCatalogQuery request)
                => new SearchCatalogSorter(request.SearchQuery);
        }
    }
}
