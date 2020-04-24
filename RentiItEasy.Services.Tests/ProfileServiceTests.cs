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

    public class ProfileServiceTests
    {
        [Fact]
        public void GetAgenciesShouldReturnAgenciesCountNotNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "Get_Agencies_from_database")
                 .Options;


            var agency = new AgencyProfile { Id = "agencyId" };
            int count;

            using (var db = new ApplicationDbContext(options))
            {
                db.AgenciesProfiles.Add(agency);
                db.SaveChanges();

                IProfileService service = new ProfileService(db);
                List<AgencyProfile> agencies = service.GetAgencies().ToList();
                count = agencies.Count();
            }

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetAgencyByIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_AgencyById_from_database")
                .Options;

            var agency = new AgencyProfile { Id = "agencyId", Username = "Agnecy" };
            AgencyProfile expectedAgency;

            using (var db = new ApplicationDbContext(options))
            {
                db.AgenciesProfiles.Add(agency);
                db.SaveChanges();

                IProfileService service = new ProfileService(db);
                expectedAgency = service.GetAgencyById(agency.Id);
            }

            Assert.Equal(agency.Username, expectedAgency.Username);
        }

        [Fact]
        public void GetUserByUsernameTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Get_UserById_from_database")
               .Options;

            var userProfile = new UserProfile { Id = "userId", Username = "User" };
            UserProfile expectedUser;

            using (var db = new ApplicationDbContext(options))
            {
                db.UsersProfiles.Add(userProfile);
                db.SaveChanges();

                IProfileService service = new ProfileService(db);
                expectedUser = service.GetUserByUsername(userProfile.Username);
            }

            Assert.Equal(userProfile.Id, expectedUser.Id);
        }

        [Fact]
        public void RateTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Rate_Agency")
           .Options;

            var userProfile = new UserProfile();

            var profile = new AgencyProfile
            {
                Rating = new Rating
                {
                    AverageRating = 0,
                    RatingSum = 0,
                    CountOfVotes = 0,
                }
            };

            int countOfUsersRatings;
            using (var db = new ApplicationDbContext(options))
            {
                db.AgenciesProfiles.Add(profile);
                db.UsersProfiles.Add(userProfile);
                db.SaveChanges();

                IProfileService service = new ProfileService(db);
                service.Rate(userProfile, profile, 4);
                countOfUsersRatings = db.UsersRatings.Count();
            }

            Assert.Equal(1, profile.Rating.CountOfVotes);
            Assert.Equal(4, profile.Rating.AverageRating);
            Assert.Equal(4, profile.Rating.RatingSum);
            Assert.Equal(1, countOfUsersRatings);
        }

        [Fact]
        public void GetUserRatingTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "Get_UserRating_from_database")
              .Options;

            var user = new UserProfile { Id = "userId" };
            var rating = new Rating { Id = "agencyId" };
            var agency = new AgencyProfile { Id = "agencyId", RatingId = rating.Id };
            var expectedRating = new UserRating { RatingId = rating.Id, UserProfileId = user.Id };
            UserRating actualRating;

            using (var db = new ApplicationDbContext(options))
            {
                db.UsersRatings.Add(expectedRating);
                db.AgenciesProfiles.Add(agency);
                db.Ratings.Add(rating);
                db.UsersProfiles.Add(user);
                db.SaveChanges();

                IProfileService service = new ProfileService(db);
                actualRating = service.GetUserRating(agency.Id);
            }

            Assert.Equal(expectedRating.RatingId, actualRating.RatingId);
        }
    }
}
