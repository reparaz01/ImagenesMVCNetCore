using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;

namespace ImagenesMVCNetCore.Helpers
{
    public enum Folders { Aristas = 0, Usuarios = 1}
    public class HelperPathProvider
    {
        private readonly IServer server;
        private readonly IWebHostEnvironment hostEnvironment;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IServer server)
        {
            this.server = server;
            this.hostEnvironment = hostEnvironment;
        }

        public string GetFolderPath(Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Aristas)
            {
                carpeta = "Artistas";
            }
            else if (folder == Folders.Usuarios)
            {
                carpeta = "usuarios";
            }

            return carpeta;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = this.GetFolderPath(folder);
            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }

        public string MapUrlPath(string fileName, Folders folder)
        {
            string carpeta = this.GetFolderPath(folder);
            var addresses = server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = addresses.FirstOrDefault();
            string urlPath = serverUrl + "/" + carpeta + "/" + fileName;
            return urlPath;
        }

    }
}