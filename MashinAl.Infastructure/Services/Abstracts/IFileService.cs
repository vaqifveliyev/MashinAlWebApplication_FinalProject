using Microsoft.AspNetCore.Http;

namespace MashinAl.Infastructure.Services.Abstracts
{
    public interface IFileService
    {
        string Upload(IFormFile file);
    }
}
