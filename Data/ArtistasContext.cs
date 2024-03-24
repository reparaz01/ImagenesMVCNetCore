using Microsoft.EntityFrameworkCore;
using ImagenesMVCNetCore.Models;

namespace ImagenesMVCNetCore.Data
{
    public class ArtistasContext : DbContext
    {
        public ArtistasContext(DbContextOptions<ArtistasContext> options)
            : base(options)
        {
        }
        public DbSet<Artista> Artistas { get; set; }

    }
}
