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

        public IActionResult AllAds()
        {
            var adsFromService = adService.GetAllAds();

            var viewModel = adsFromService.Select(a => new AdViewModel
            {
                Title = a.Title,
                Description = a.Description,
                Path = GlobalConstants.cloudinary + a.ImagesPaths.First().Path,
                Id = a.Id,
            })
                .ToList();

            return View(viewModel);
        }
    }
}
