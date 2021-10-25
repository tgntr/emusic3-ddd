﻿namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    using Common;
    using MediatR;
    using SimpleMusicStore.Application.Common.Pagination;
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog.Models;
    using SimpleMusicStore.Domain.Catalog.Specifications;
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
        public MusicRecordSortType? SortBy { private get; set; }
        public OrderType? OrderBy { private get; set; }

        Specification<MusicRecord> GetSpecifications()
        {
            return new MusicRecordByAudioFormatSpecification(Format)
                .And(new MusicRecordByGenreSpecification(Genres, Styles))
                .And(new MusicRecordByPriceRangeSpecification(MinPrice, MaxPrice))
                .And(new MusicRecordByReleaseDateRangeSpecification(MinReleaseDate, MaxReleaseDate))
                .And(new MusicRecordBySearchQuerySpecification(SearchQuery))
                .And(new MusicRecordOnlyAvailableSpecification(OnlyAvailable));
        }

        MusicRecordSorter GetSorter()
        {
            return new MusicRecordSorter(SortBy, OrderBy, SearchQuery);
        }

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
                return await _inventoryQueryRepository.Search(
                    request.GetSpecifications(),
                    request.GetSorter(),
                    request.Page,
                    cancellationToken);
            }
        }
    }
}