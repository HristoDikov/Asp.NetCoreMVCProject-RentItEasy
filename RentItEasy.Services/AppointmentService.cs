namespace RentItEasy.Services
{
    using RentItEasy.Data;
    using RentItEasy.Data.Models;
    using RentItEasy.Services.Contracts;
    using System;
    using System.Threading.Tasks;

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext db;
        //private readonly AdService adService;
        //private readonly AccountService accountService;
        public AppointmentService(ApplicationDbContext db /*ApplicationDbContext db, AccountService accountService*/)
        {
            //this.adService = adService;
            //this.accountService = accountService;
            this.db = db;
        }

        public void Create(Ad Ad, UserProfile userProfile, AgencyProfile agencyProfile, DateTime date)
        {
            Appointment appointment = new Appointment
            {
                Ad = Ad,
                Date = date,
            };

            if (userProfile != null)
            {
                appointment.UserProfile = userProfile;
            }
            else
            {
                appointment.AgencyProfile = agencyProfile;
            }


            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();
        }
    }
}
