namespace RentItEasy.Areas.User.Controllers
{
    using global::RentItEasy.Areas.User.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Area("User")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IAccountService accountService;
        private readonly IAdService adService;

        public AppointmentController(IAppointmentService appointmentService, IAccountService accountService, IAdService adService)
        {
            this.appointmentService = appointmentService;
            this.accountService = accountService;
            this.adService = adService;
        }

        [HttpGet]
        public IActionResult CreateAppointment(int id)
        {
            this.ViewBag.Id = id;
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            if (model.AppointmentDate < DateTime.UtcNow)
            {
                return this.View(model);
            }
            if (model.AppointmentDate > DateTime.UtcNow.AddDays(10))
            {
                return this.View(model);
            }

            var username = this.User.Identity.Name;
            var ad = adService.GetAd(model.AdId);
            var userProfile = accountService.GetUserByUsername(username);
            var agencyProfile = accountService.GetAgencyByUsername(username);

            appointmentService.Create(ad, userProfile, agencyProfile, model.AppointmentDate);

            return this.Redirect(GlobalConstants.homeUrl);
        }
    }
}
