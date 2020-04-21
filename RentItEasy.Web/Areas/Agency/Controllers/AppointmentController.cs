namespace RentItEasy.Areas.Agency.Controllers
{
    using global::RentItEasy.Areas.User.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Area(GlobalConstants.agencyRoleName)]
    [Authorize(Roles = GlobalConstants.agencyRoleName)]

    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        public IActionResult GetAppointments()
        {
            var username = this.User.Identity.Name;

            var fullAppointmentInfo = appointmentService.GetMyAppointments(username);
            var appointments = new List<AppointmentViewModel>();

            foreach (var appointment in fullAppointmentInfo)
            {
                var app = new AppointmentViewModel
                {
                    Id = appointment.Id,
                    Title = appointment.Ad.Title,
                    UserFirstName = appointment.UserProfile.FirstName,
                    UserLastName = appointment.UserProfile.LastName,
                    PhoneNumber = appointment.UserProfile.PhoneNumber,
                };

                appointments.Add(app);
            }

            return this.View(appointments);
        }

        public async Task<IActionResult> Arranged(int id)
        {
            await this.appointmentService.DeleteAppointment(id);

            //TODO
            return this.RedirectToAction("GetAppointments");
        }
    }
}
