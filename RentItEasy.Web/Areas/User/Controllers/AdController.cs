namespace RentItEasy.Areas.User.Controllers
{
    using global::RentItEasy.Areas.Agency.Ad.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    [Area(GlobalConstants.userRoleName)]
    [Authorize]
    public class AdController : Controller
    {
        private readonly IAdService adService;

        public AdController(IAdService adService)
        {
            this.adService = adService;
        }

        public IActionResult AllAds(int page = 1)
        {
            int skip = (page - 1) * GlobalConstants.ItemsPerPage;
            var adsFromService = adService.GetAllAds(GlobalConstants.ItemsPerPage, skip);

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
