namespace RentItEasy.Areas.User.Controllers
{
    using CloudinaryDotNet;
    using global::RentItEasy.Areas.User.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("User")]
    public class AdController : Controller
    {
        private IAdService adService;
        private IUploadImageService uploadImageadService;
        private Cloudinary cloudinary;

        public AdController(IUploadImageService uploadImageadService, Cloudinary cloudinary, IAdService adService)
        {
            this.adService = adService;
            this.uploadImageadService = uploadImageadService;
            this.cloudinary = cloudinary;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(CreateAdInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var stringImagesPaths = await this.uploadImageadService.UploadImage(cloudinary, model.Images);

            var userName = this.User.Identity.Name;

            await this.adService.CreateAd(userName, model.Title, model.Description, stringImagesPaths, model.PropertyType,
                model.Size, model.Location, model.RentPrice, model.BuildingClass);

            return this.Redirect(GlobalConstants.homeUrl);
        }

        public IActionResult MyAds()
        {
            var currentUserProfile = this.User.Identity.Name;

            var model = this.adService.GetUserAds(currentUserProfile);

            return View(model);
        }
    }
}
