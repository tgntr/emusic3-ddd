using Microsoft.EntityFrameworkCore;
using SimpleMusicStore.Domain.Catalog.Models;
using SimpleMusicStore.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Infrastructure.Catalog
{
    internal interface ICatalogDbContext : IDbContext
    {
        DbSet<MusicRecord> MusicRecords { get; }
        DbSet<Artist> Artists { get; }
        DbSet<Label> Labels { get; }
    }
}
