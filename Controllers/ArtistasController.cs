using ImagenesMVCNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using ImagenesMVCNetCore.Repositories;
using ImagenesMVCNetCore.Helpers;

namespace ImagenesMVCNetCore.Controllers
{
    public class ArtistasController : Controller
    {
        private RepositoryArtistas repo;
        private HelperPathProvider helper;

        public ArtistasController(RepositoryArtistas repo, HelperPathProvider helper)
        {
            this.repo = repo;
            this.helper = helper;

        }


        public async Task<IActionResult> Index()
        {
            List<Artista> artistas = await this.repo.GetArtistasAsync();
            return View(artistas);
        }


        [HttpPost]
        public async Task<IActionResult> EliminarArtista(int id)
        {
            var artista = repo.FindArtistaAsync(id).Result;
            if (artista == null)
            {
                return NotFound(); 
            }

            string fileName = artista.Foto;
            string path = this.helper.MapPath(fileName, Folders.Aristas);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await this.repo.DeleteArtistaAsync(artista);

            return RedirectToAction("Index", "Artistas");
        }

    }
}
