namespace RentItEasy.Areas.User.Controllers
{
    using global::RentItEasy.Areas.User.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Area(GlobalConstants.userRoleName)]
    [Authorize(Roles = GlobalConstants.userRoleName)]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IAccountService accountService;
        private readonly IProfileService profileService;
        private readonly IAdService adService;

        public AppointmentController(IProfileService profileService, IAppointmentService appointmentService, IAccountService accountService, IAdService adService)
        {
            this.appointmentService = appointmentService;
            this.accountService = accountService;
            this.adService = adService;
            this.profileService = profileService;
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
            var userProfile = profileService.GetUserByUsername(username);
            var agencyProfile = profileService.GetAgencyById(ad.AgencyProfileId);

            appointmentService.Create(ad, userProfile, agencyProfile, model.AppointmentDate);

            return this.Redirect(GlobalConstants.homeUrl);
        }
    }
}
