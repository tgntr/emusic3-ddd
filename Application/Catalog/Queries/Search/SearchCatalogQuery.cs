namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    using Common;
    using MediatR;
    using SimpleMusicStore.Application.Catalog.Queries.Search;
    using SimpleMusicStore.Application.Common.Pagination;
    using SimpleMusicStore.Application.Common.Sorting;
    using SimpleMusicStore.Domain.Catalog.Models;
    using SimpleMusicStore.Domain.Catalog.Specifications;
    using SimpleMusicStore.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchCatalogQuery : PagedQuery, IRequest<IEnumerable<SearchCatalogOutputModel>>
    {
        public string? SearchQuery { private get; set; }

        public class SearchCatalogQueryHandler : IRequestHandler<SearchCatalogQuery, IEnumerable<SearchCatalogOutputModel>>
        {
            private readonly ICatalogQueryRepository _inventoryQueryRepository;

            public SearchCatalogQueryHandler(
                ICatalogQueryRepository inventoryQueryRepository)
            {
                _inventoryQueryRepository = inventoryQueryRepository;
            }

            public async Task<IEnumerable<SearchCatalogOutputModel>> Handle(
                SearchCatalogQuery request,
                CancellationToken cancellationToken)
            {
                return await Task.FromResult<IEnumerable<SearchCatalogOutputModel>>(null!);
            }
        }
    }
}
