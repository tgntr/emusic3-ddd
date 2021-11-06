using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleMusicStore.Application.Catalog;
using SimpleMusicStore.Application.Catalog.Queries.Browse;
using SimpleMusicStore.Application.Catalog.Queries.Search;
using SimpleMusicStore.Domain.Catalog.Models;
using SimpleMusicStore.Domain.Catalog.Repositories;
using SimpleMusicStore.Domain.Catalog.Specifications.Search;
using SimpleMusicStore.Domain.Common;
using SimpleMusicStore.Infrastructure.Common;
using SimpleMusicStore.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMusicStore.Infrastructure.Catalog.Repositories
{
    internal class CatalogRepository : DataRepository<ICatalogDbContext, MusicRecord>,
        ICatalogDomainRepository,
        ICatalogQueryRepository
    {
        private readonly IConfigurationProvider _mapper;

        public CatalogRepository(ICatalogDbContext db, IMapper mapper)
            : base(db)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<IEnumerable<BrowseCatalogMusicRecordOutputModel>> BrowseMusicRecords(
            Specification<MusicRecord> specifications,
            BrowseCatalogSorter sorter,
            int page,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(specifications)
                .Sort(sorter)
                .ToPage(page)
                .ProjectTo<BrowseCatalogMusicRecordOutputModel>(_mapper)
                .ToListAsync(cancellationToken);
        }

        public Task<MusicRecord> FindMusicRecord(int id, CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public Task<object> GetBrowsingOptions(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetMusicRecordDetails(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistingMusicRecord(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SearchCatalogResultOutputModel>> SearchArtists(ArtistLabelBySearchQuerySpecification searchQuery, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SearchCatalogResultOutputModel>> SearchLabels(ArtistLabelBySearchQuerySpecification searchQuery, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SearchCatalogResultOutputModel>> SearchMusicRecords(MusicRecordBySearchQuerySpecification searchQuery, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
