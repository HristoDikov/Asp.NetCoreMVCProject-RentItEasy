namespace RentItEasy.Services.Contracts
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUploadImageService
    {
        Task<IEnumerable<string>> UploadImage(Cloudinary cloudinary, IEnumerable<IFormFile> files);
    }
}
