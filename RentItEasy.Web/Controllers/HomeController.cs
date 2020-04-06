namespace RentItEasy.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using global::RentItEasy.Models;
    using global::RentItEasy.Services;
    using global::RentItEasy.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAdService adService;

        public HomeController(ILogger<HomeController> logger, IAdService adService)
        {
            _logger = logger;
            this.adService = adService;
        }

        public IActionResult Index()
        {
            var adsFromService = adService.GetTenOfMostVisitedAds();

            List<AdViewModel> viewModel = adsFromService.Select(a => new AdViewModel
            {
                Title = a.Title,
                Description = a.Description,
                CountOfVisits = a.CountOfVisits,
                RentPrice = a.Property.RentPrice,
                Size = a.Property.Size,
                Location = a.Property.Location,
                PropertyType = a.Property.PropertyType.ToString(),
                BuildingClass = a.Property.BuildingClass.ToString(),
            }).ToList();

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
