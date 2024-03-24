using ImagenesMVCNetCore.Helpers;
using ImagenesMVCNetCore.Models;
using ImagenesMVCNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ImagenesMVCNetCore.Controllers
{
    public class NuevoArtistaController : Controller
    {

        private RepositoryArtistas repo;
        private HelperPathProvider helper;

        public NuevoArtistaController(RepositoryArtistas repo, HelperPathProvider helper)
        {
            this.repo = repo;
            this.helper = helper;

        }


        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNuevoArtista(Artista artista, IFormFile foto)
        {
            Artista nuevoArtista = new Artista();

            nuevoArtista.Nombre = artista.Nombre;

            string fileName = "" +  artista.Nombre + ".jpeg";
            string path = this.helper.MapPath(fileName, Folders.Aristas);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await foto.CopyToAsync(stream);
            }

            nuevoArtista.Foto = fileName;

            await this.repo.AddArtistaAsync(nuevoArtista);

            return RedirectToAction("Index", "Artistas");
        }

    }
}
