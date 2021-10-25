using SimpleMusicStore.Application.Common.Mapping;
using SimpleMusicStore.Domain.Catalog.Models;
using System;
using System.Collections.Generic;

namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    public class BrowseCatalogMusicRecordOutputModel : IMapFrom<MusicRecord>
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public DateTime DateReleased { get; set; }
        public SearchCatalogArtistLabelOutputModel Label { get; set; } = default!;
        public IEnumerable<SearchCatalogArtistLabelOutputModel> Artists { get; set; } = default!;
        public decimal Price { get; set; }

        public class SearchCatalogArtistLabelOutputModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
        }
    }
}
