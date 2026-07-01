using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Margorak.Api.Data
{

    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<MapTile> MapTiles => Set<MapTile>();
        public DbSet<Map> Maps => Set<Map>();
        public DbSet<Terrain> Terrains => Set<Terrain>();
        
    }
}
