namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    using MediatR;
    using SimpleMusicStore.Application.Common.Pagination;
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog.Models;
    using SimpleMusicStore.Domain.Catalog.Specifications.Browse;
    using SimpleMusicStore.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class BrowseCatalogQuery : PagedQuery, IRequest<IEnumerable<BrowseCatalogMusicRecordOutputModel>>
    {
        public AudioFormat? Format { private get; set; }
        public IEnumerable<string>? Genres { private get; set; }
        public IEnumerable<string>? Styles { private get; set; }
        public decimal? MinPrice { private get; set; }
        public decimal? MaxPrice { private get; set; }
        public DateTime? MinReleaseDate { private get; set; }
        public DateTime? MaxReleaseDate { private get; set; }
        public string? SearchQuery { private get; set; }
        public bool? OnlyAvailable { private get; set; }
        public BrowseCatalogSortType? SortBy { private get; set; }
        public OrderType? OrderBy { private get; set; }

        public class BrowseCatalogQueryHandler : IRequestHandler<BrowseCatalogQuery, IEnumerable<BrowseCatalogMusicRecordOutputModel>>
        {
            private readonly ICatalogQueryRepository _inventoryQueryRepository;

            public BrowseCatalogQueryHandler(
                ICatalogQueryRepository inventoryQueryRepository)
            {
                _inventoryQueryRepository = inventoryQueryRepository;
            }

            public async Task<IEnumerable<BrowseCatalogMusicRecordOutputModel>> Handle(
                BrowseCatalogQuery request,
                CancellationToken cancellationToken)
            {
                return await _inventoryQueryRepository.BrowseMusicRecords(
                    GetBrowseSpecification(request),
                    GetBrowseSorter(request),
                    request.Page,
                    cancellationToken);
            }

            private Specification<MusicRecord> GetBrowseSpecification(BrowseCatalogQuery request)
            {
                return new MusicRecordByAudioFormatSpecification(request.Format)
                    .And(new MusicRecordByGenreSpecification(request.Genres, request.Styles))
                    .And(new MusicRecordByPriceRangeSpecification(request.MinPrice, request.MaxPrice))
                    .And(new MusicRecordByReleaseDateRangeSpecification(request.MinReleaseDate, request.MaxReleaseDate))
                    .And(new MusicRecordByBrowseSearchQuerySpecification(request.SearchQuery))
                    .And(new MusicRecordOnlyAvailableSpecification(request.OnlyAvailable));
            }
            private BrowseCatalogSorter GetBrowseSorter(BrowseCatalogQuery request)
            {
                return new BrowseCatalogSorter(request.SortBy, request.OrderBy);
            }
        }
    }
}
