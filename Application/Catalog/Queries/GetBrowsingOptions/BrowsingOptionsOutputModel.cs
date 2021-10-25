using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Application.Catalog.Queries.GetBrowsingOptions
{
    public class BrowsingOptionsOutputModel
    {
        public IEnumerable<string> AvailableGenres { get; set; } = default!;
        public IEnumerable<string> AvailableFormats { get; set; } = default!;
        public IEnumerable<string> AvailableSortTypes { get; set; } = default!;
    }
}
