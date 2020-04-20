namespace RentItEasy.Areas.Agency.Controllers
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Areas.User.ViewModels;
    using Common;
    using Data.Models;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Agency")]
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly IUploadImageService uploadImageadService;
        private readonly Cloudinary cloudinary;

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

        [HttpPost]
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

            var ads = this.adService.GetAgencyAds(userName);
            var minimizedAds = AdToMinimizedAdViewModel(ads);

            return this.View("MyAds", minimizedAds);
        }

        [HttpGet]
        public IActionResult MyAds()
        {
            var currentUserProfile = this.User.Identity.Name;

            var ads = this.adService.GetAgencyAds(currentUserProfile);

            var model = AdToMinimizedAdViewModel(ads);

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewAd(int id)
        {
            var ad = this.adService.GetAd(id);

            var model = new FullAdViewModel
            {
                Id = ad.Id,
                MadeBy = ad.AgencyProfile == null ? ad.UserProfile.Username ?? ad.AgencyProfile.Username : ad.AgencyProfile.Username,
                Title = ad.Title,
                Description = ad.Description,
                RentPrice = ad.RentPrice,
                BuildingClass = ad.BuildingClass,
                Location = ad.Location,
                PropertyType = ad.PropertyType,
                Size = ad.Size,
                CreatedOn = ad.CreatedOn,
            };

            var imgPaths = new List<ImagePath>();

            foreach (var imgPath in ad.ImagesPaths)
            {
                imgPaths.Add(imgPath);
            }

            model.ImagesPaths = CreateFullUrlImage(imgPaths);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult EditAd(int id)
        {
            var ad = adService.GetAd(id);

            var model = new FullAdViewModel
            {
                Id = ad.Id,
                Title = ad.Title,
                Description = ad.Description,
                RentPrice = ad.RentPrice,
                BuildingClass = ad.BuildingClass,
                Location = ad.Location,
                PropertyType = ad.PropertyType,
                Size = ad.Size,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditAd(CreateAdInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await adService.EditAd(model.Id, model.Title, model.Description, model.PropertyType, model.Size,
                model.Location, model.RentPrice, model.BuildingClass);

            var currentUserProfile = this.User.Identity.Name;
            var ads = this.adService.GetAgencyAds(currentUserProfile);
            var minimizedAds = AdToMinimizedAdViewModel(ads);

            return this.View("MyAds", minimizedAds);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAd(int id)
        {
            await adService.DeleteAd(id);


            return this.Redirect(GlobalConstants.homeUrl);
        }

        private IEnumerable<ImagePath> CreateFullUrlImage(IEnumerable<ImagePath> ads)
        {
            foreach (var ad in ads)
            {
                ad.Path = GlobalConstants.cloudinary + ad.Path;
            }

            return ads;
        }

        private IEnumerable<AdViewModel> AdToMinimizedAdViewModel(IEnumerable<Ad> ads)
        {
            var minimizedAds = new List<AdViewModel>();

            foreach (var ad in ads)
            {
                var minimizedAd = new AdViewModel
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    Path = GlobalConstants.cloudinary + ad.ImagesPaths.First().Path
                };

                minimizedAds.Add(minimizedAd);
            }

            return minimizedAds;
        }

    }
}
