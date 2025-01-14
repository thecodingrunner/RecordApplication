using Microsoft.EntityFrameworkCore;
using RecordApplication.Entities;

namespace RecordApplication
{
    public class AlbumDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public AlbumDbContext(DbContextOptions<AlbumDbContext> options) : base(options)
        {
        }
    }
}
