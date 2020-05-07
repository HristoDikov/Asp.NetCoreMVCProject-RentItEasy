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

    public class AdServicesTests
    {
        [Fact]
        public async Task CreateAdTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Create_Ad")
                     .Options;

            IEnumerable<string> imgP = new List<string> { "aaaaa", "bbbbbb" };
            var user = new AgencyProfile { Id = "agencyId", Username = "Name" };

            int count;

            using (var db = new ApplicationDbContext(options))
            {
                db.AgenciesProfiles.Add(user);
                db.SaveChanges();
                AdService service = new AdService(db);

                await service.CreateAd("Name", "Titleeeeeeeeeeeeee", "Description", imgP, "Residental",
                    "65", "Location", "20", "A");

                count = db.Ads.Count();
            }

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetAd()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: "Get_Ad")
                   .Options;

            var ad = new Ad { Id = 1 };
            Ad expectedAd;

            using (var db = new ApplicationDbContext(options))
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                AdService service = new AdService(db);
                expectedAd = service.GetAd(ad.Id);
            }

            Assert.Equal(ad.Id, expectedAd.Id);
        }


        [Fact]
        public async Task Edit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: "Edit_Ad")
                   .Options;

            var user = new AgencyProfile { Id = "agencyId", Username = "Name" };
            var ad = new Ad { Id = 1, Title = "AAAAAAAA"};
            var adTitle = ad.Title;
            int count;

            using (var db = new ApplicationDbContext(options))
            {
                db.AgenciesProfiles.Add(user);
                db.Ads.Add(ad);
                db.SaveChanges();
                AdService service = new AdService(db);

                await service.EditAd(1, "Titleeeeeeeeeeeeee", "Description", "Residental",
                    "65", "Location", "20", "A");

                count = db.Ads.Count();
            }

            Assert.NotEqual(adTitle, ad.Title);
        }


        [Fact]
        public async Task DeleteAdTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: "Delete_Ad")
                   .Options;

            var ad = new Ad { Id = 1 };
            int countAfterAdd;
            int countAfterDelete;

            using (var db = new ApplicationDbContext(options))
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                countAfterAdd = db.Ads.Count();

                AdService service = new AdService(db);
                await service.DeleteAd(ad.Id);
                countAfterDelete = db.Ads.Count();
            }

            Assert.NotEqual(countAfterAdd, countAfterDelete);
        }
    }

}