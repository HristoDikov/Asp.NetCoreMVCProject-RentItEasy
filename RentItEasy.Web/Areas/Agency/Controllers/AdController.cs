namespace RentItEasy.Areas.Agency.Controllers
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Common;
    using Data.Models;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::RentItEasy.Areas.Agency.Ad.ViewModels;

    [Area(GlobalConstants.agencyRoleName)]
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
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
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
            var minimizedAds = AdToAdViewModel(ads);

            return this.View("MyAds", minimizedAds);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
        public IActionResult MyAds(int page = 1)
        {
            var currentUserProfile = this.User.Identity.Name;

            var ads = this.adService.GetAgencyAds(currentUserProfile);

            int skip = (page - 1) * GlobalConstants.ItemsPerPage;
            var adsFromService = adService.GetAgencyAds(currentUserProfile, GlobalConstants.ItemsPerPage, skip);

            int count = this.adService.GetAdsByAgencyCount(currentUserProfile);

            var model = new AdViewModel
            {
                PagesCount = (int)Math.Ceiling((double)count / GlobalConstants.ItemsPerPage),
                CurrentPage = page,
                MinimizedAds = ads.Select(a => new MinimizedAdViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Path = GlobalConstants.cloudinary + a.ImagesPaths.First().Path
                })
               .ToList()
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ViewAd(int id)
        {
            var ad = this.adService.GetAd(id);

            var model = new FullAdViewModel
            {
                Id = ad.Id,
                MadeBy = ad.AgencyProfile.Username,
                Title = ad.Title,
                Description = ad.Description,
                RentPrice = ad.RentPrice,
                BuildingClass = ad.BuildingClass,
                Location = ad.Location,
                PropertyType = ad.PropertyType,
                Size = ad.Size,
                CreatedOn = ad.CreatedOn.ToString("MM/dd/yyyy"),
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
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
        public IActionResult EditAd(int id)
        {
            var ad = adService.GetAd(id);

            var model = new EditAdInputModel
            {
                Id = ad.Id,
                Title = ad.Title,
                Description = ad.Description,
                RentPrice = ad.RentPrice,
                BuildingClass = ad.BuildingClass.ToString(),
                Location = ad.Location,
                PropertyType = ad.PropertyType.ToString(),
                Size = ad.Size,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
        public async Task<IActionResult> EditAd(EditAdInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await adService.EditAd(model.Id, model.Title, model.Description, model.PropertyType, model.Size,
     model.Location, model.RentPrice, model.BuildingClass);

            var currentUserProfile = this.User.Identity.Name;
            var ads = this.adService.GetAgencyAds(currentUserProfile);
            var minimizedAds = AdToAdViewModel(ads);

            return this.View("MyAds", minimizedAds);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.agencyRoleName)]
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

        private AdViewModel AdToAdViewModel(IEnumerable<Ad> ads)
        {
            var AdViewModel = new AdViewModel
            {
                CurrentPage = 1,
                PagesCount = 1,
                MinimizedAds = ads.Select(a => new MinimizedAdViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Path = GlobalConstants.cloudinary + a.ImagesPaths.First().Path
                })
                .ToList()
            };
            return AdViewModel;
        }

    }
}
