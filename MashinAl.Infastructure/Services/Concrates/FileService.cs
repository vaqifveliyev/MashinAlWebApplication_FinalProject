using MashinAl.Infastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace MashinAl.Infastructure.Services.Concrates
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment environment;

        public FileService(IHostEnvironment environment)
        {
            this.environment = environment;
        }
        public string Upload(IFormFile file)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string physicalPath = Path.Combine(environment.ContentRootPath, "wwwroot", "uploads", "images", fileName);

            using (FileStream fs = new FileStream(physicalPath, FileMode.CreateNew, FileAccess.Write))
            {
                file.CopyTo(fs);
            }

            return fileName;
        }
    }
}
