namespace RentItEasy.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data;
    using RentItEasy.Data.Models;
    using RentItEasy.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext db;
        public AppointmentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Ad ad, UserProfile userProfile, AgencyProfile agencyProfile, DateTime date)
        {

            Appointment appointment = new Appointment
            {
                AdId = ad.Id,
                Date = date,
                UserProfileId = userProfile.Id,
                AgencyProfileId = agencyProfile.Id,
            };

             this.db.Appointments.Add(appointment);
             this.db.SaveChanges();
        }

        public IEnumerable<Appointment> GetMyAppointments(string username)
        {
            var agency = this.db.AgenciesProfiles
            .Where(a => a.Username == username)
            .FirstOrDefault();

            var agencyApp = this.db.Appointments
                .Select(ap => new Appointment
                {
                    Id = ap.Id,
                    Ad = new Ad { Title = ap.Ad.Title },
                    UserProfile = new UserProfile
                    {
                        FirstName = ap.UserProfile.FirstName,
                        LastName = ap.UserProfile.LastName,
                        PhoneNumber = ap.UserProfile.PhoneNumber,
                    },
                    AgencyProfileId = ap.AgencyProfileId,
                })
                .Where(a => a.AgencyProfileId == agency.Id)
                .ToList();

            return agencyApp;
        }

        public async Task DeleteAppointment(int id)
        {
            var app = this.db.Appointments
           .Where(a => a.Id == id)
           .Select(a => a)
           .FirstOrDefault();

            this.db.Appointments.Remove(app);

            await this.db.SaveChangesAsync();
        }
    }
}
