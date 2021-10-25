namespace SimpleMusicStore.Application.Catalog.Queries.Search
{
    using MediatR;
    using SimpleMusicStore.Application.Common;
    using SimpleMusicStore.Domain.Catalog.Specifications.Search;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchCatalogQuery
        : PagedQuery, IRequest<IEnumerable<SearchCatalogResultOutputModel>>
    {
        public string SearchQuery { get; set; } = default!;

        internal MusicRecordBySearchQuerySpecification MusicRecordSpecification
            => new MusicRecordBySearchQuerySpecification(SearchQuery);

        internal ArtistLabelBySearchQuerySpecification ArtistLabelSpecification
            => new ArtistLabelBySearchQuerySpecification(SearchQuery);

        internal SearchCatalogSorter Sorter
            => new SearchCatalogSorter(SearchQuery);
    }

    public class SearchCatalogQueryHandler
        : IRequestHandler<SearchCatalogQuery, IEnumerable<SearchCatalogResultOutputModel>>
    {
        private readonly ICatalogQueryRepository _catalogQueryRepository;

        public SearchCatalogQueryHandler(
            ICatalogQueryRepository catalogQueryRepository)
        {
            _catalogQueryRepository = catalogQueryRepository;
        }

        public async Task<IEnumerable<SearchCatalogResultOutputModel>> Handle(
            SearchCatalogQuery request,
            CancellationToken cancellationToken)
        {
            var musicRecords = await _catalogQueryRepository
                .SearchMusicRecords(request.MusicRecordSpecification, cancellationToken);

            var artists = await _catalogQueryRepository
                .SearchArtists(request.ArtistLabelSpecification, cancellationToken);

            var labels = await _catalogQueryRepository
                .SearchLabels(request.ArtistLabelSpecification, cancellationToken);

            //todo paging and cache
            return musicRecords
                .Concat(artists)
                .Concat(labels)
                .OrderByDescending(request.Sorter.Sort())
                .Take(10);
        }
    }
}
