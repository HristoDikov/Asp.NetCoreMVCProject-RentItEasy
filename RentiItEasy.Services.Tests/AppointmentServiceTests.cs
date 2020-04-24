namespace RentiItEasy.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data.Models;
    using RentItEasy.Data;
    using System;
    using Xunit;
    using RentItEasy.Services.Contracts;
    using RentItEasy.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentServiceTests
    {
        [Fact]
        public void CreateAppointmentTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_Appointment")
                .Options;

            var appointment = new Appointment { Id = 1 };
            var user = new UserProfile { Id = "userId" };
            var agency = new AgencyProfile { Id = "agencyId" };
            var ad = new Ad { Id = 2 };
            var date = DateTime.UtcNow;

            int count;

            using (var db = new ApplicationDbContext(options))
            {
                AppointmentService service = new AppointmentService(db);
                service.Create(ad, user, agency, date);
                count = db.Appointments.Count();
            }

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetMyAppointmentTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Get_Appointment")
               .Options;

            var user = new UserProfile { Id = "userId" };
            var ad = new Ad { Id = 2 };
            var appointment = new Appointment
            {
                Id = 1,
                AgencyProfileId = "agencyId",
                AdId = ad.Id,
                UserProfileId = user.Id,
            };

            var agency = new AgencyProfile
            {
                Id = "agencyId",
                Username = "agencyName",
            };

            agency.Appointments.Add(appointment);
            agency.Ads.Add(ad);

            List<Appointment> apps;

            using (var db = new ApplicationDbContext(options))
            {
                db.Appointments.Add(appointment);
                db.AgenciesProfiles.Add(agency);
                db.SaveChanges();
                AppointmentService service = new AppointmentService(db);

                apps = service.GetMyAppointments(agency.Username).ToList();
            }

            Assert.Single(apps);
        }


        [Fact]
        public async Task DeleteAppointment()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Delete_Appointment")
               .Options;

            var appointment = new Appointment
            {
                Id = 1,
            };

            int count;

            using (var db = new ApplicationDbContext(options))
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();

                AppointmentService service = new AppointmentService(db);
                await service.DeleteAppointment(appointment.Id);
                count = db.Appointments.Count();
            }

            Assert.Equal(0, count);
        }
    }
}