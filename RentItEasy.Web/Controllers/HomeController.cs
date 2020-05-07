namespace RentItEasy.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using global::RentItEasy.Areas.Agency.Ad.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Models;
    using global::RentItEasy.Services;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IAdService adService;

        public HomeController(IAdService adService)
        {
            this.adService = adService;
        }

        public IActionResult Index()
        {
            var adsFromService = adService.GetSixAds();

            var viewModel = new AdViewModel
            {
                MinimizedAds = adsFromService.Select(a => new MinimizedAdViewModel
                {
                    Title = a.Title,
                    Description = a.Description,
                    Path = GlobalConstants.cloudinary + a.ImagesPaths.First().Path,
                    Id = a.Id,
                })
                .ToList()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
