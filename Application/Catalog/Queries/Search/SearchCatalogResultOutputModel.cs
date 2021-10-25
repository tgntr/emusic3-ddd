using SimpleMusicStore.Application.Common.Mapping;
using SimpleMusicStore.Domain.Catalog.Models;

namespace SimpleMusicStore.Application.Catalog.Queries.Search
{
    public class SearchCatalogResultOutputModel
        : IMapFrom<MusicRecord>, IMapFrom<Artist>, IMapFrom<Label>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string ContentType { get; set; } = default!;
    }
}
