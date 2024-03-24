using ImagenesMVCNetCore.Models;
using Microsoft.EntityFrameworkCore;
using ImagenesMVCNetCore.Data;


namespace ImagenesMVCNetCore.Repositories
{
    public class RepositoryArtistas
    {
        private ArtistasContext context;

        public RepositoryArtistas(ArtistasContext context)
        {
            this.context = context;
        }

        public async Task<List<Artista>> GetArtistasAsync()
        {
            return await this.context.Artistas.ToListAsync();
        }

        public async Task<Artista> FindArtistaAsync(int idArtista)
        {
            return await this.context.Artistas.FirstOrDefaultAsync(x => x.IdArtista == idArtista);
        }

        public async Task AddArtistaAsync(Artista artista)
        {

            context.Artistas.Add(artista);
            await context.SaveChangesAsync();
        }

        public async Task DeleteArtistaAsync(Artista artista)
        {
            this.context.Artistas.Remove(artista);
            await this.context.SaveChangesAsync();
        }


    }
}
