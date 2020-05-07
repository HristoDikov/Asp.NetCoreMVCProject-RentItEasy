namespace RentItEasy.Services
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using RentItEasy.Services.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class UploadImageService : IUploadImageService
    {
        public async Task<IEnumerable<string>> UploadImage(Cloudinary cloudinary, IEnumerable<IFormFile> files)
        {
            var imgPaths = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using var destinationStream = new MemoryStream(destinationImage);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream)
                };

                var result = await cloudinary.UploadAsync(uploadParams);
                var path = result.Uri.AbsolutePath;
                imgPaths.Add(path);
            }

             return imgPaths;
        }
    }
}
