using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentItEasy.Areas.Agency.ViewModels;
using RentItEasy.Common;
using RentItEasy.Services;
using RentItEasy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentItEasy.Areas.User.Controllers
{
    [Area(GlobalConstants.userRoleName)]
    [Authorize]
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly IUploadImageService uploadImageadService;

        public AdController(IUploadImageService uploadImageadService, IAdService adService)
        {
            this.adService = adService;
            this.uploadImageadService = uploadImageadService;
        }

        public IActionResult AllAds(int page = 1)
        {
            int skip = (page - 1) * GlobalConstants.ItemsPerPage;
            var adsFromService = adService.GetAllAds(page, GlobalConstants.ItemsPerPage, skip);

            int count = this.adService.GetAdsCount();

            var viewModel = new AdViewModel
            {
                PagesCount = (int)Math.Ceiling((double)count / GlobalConstants.ItemsPerPage),
                CurrentPage = page,
                MinimizedAds = adsFromService.Select(a => new MinimizedAdViewModel
                {
                    Title = a.Title,
                    Description = a.Description,
                    Path = GlobalConstants.cloudinary + a.ImagesPaths.First().Path,
                    Id = a.Id,
                })
                .ToList(),
            };

            return View(viewModel);
        }
    }
}
