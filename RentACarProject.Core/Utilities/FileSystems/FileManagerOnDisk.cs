using Microsoft.AspNetCore.Http;
using System.IO;

namespace RentACarProject.Core.Utilities.FileSystems
{
    public class FileManagerOnDisk : IFileSystem
    {
        public string Add(IFormFile file, string path)
        {
            var sourcepath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(sourcepath, path);

            return path;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public string Update(string pathToUpdate, IFormFile file, string path)
        {
            if (path.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(pathToUpdate);

            return path;
        }
    }
}
