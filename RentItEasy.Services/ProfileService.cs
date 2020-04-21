using RentItEasy.Data.Models;
namespace RentItEasy.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data;
    using RentItEasy.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext db;

        public ProfileService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Rate(UserProfile userProfile, AgencyProfile agencyProfile, decimal rateDigit)
        {
            agencyProfile.Rating.RatingSum += rateDigit;
            agencyProfile.Rating.CountOfVotes++;
            agencyProfile.Rating.AverageRating = agencyProfile.Rating.RatingSum / agencyProfile.Rating.CountOfVotes;

            var userRating = new UserRating
            {
                UserProfile = userProfile,
                UserProfileId = userProfile.Id,
                RatingId = agencyProfile.Rating.Id,
                Rating = agencyProfile.Rating,
            };

            userProfile.Ratings.Add(userRating);
            agencyProfile.Rating.VotedUsers.Add(userRating);

            db.SaveChanges();
        }

        public IEnumerable<AgencyProfile> GetAgencies()
        {
            var agencies = this.db.AgenciesProfiles
                .Include(ap => ap.Rating)
                .Select(ap => ap)
                .OrderBy(ap => ap.Name)
                .ToList();

            return agencies;
        }

        public AgencyProfile GetAgencyById(string id)
        {
            var agency = this.db.AgenciesProfiles
                .Include(ap => ap.Rating)
                .ThenInclude(ap => ap.VotedUsers)
                .ThenInclude(u => u.UserProfile)
                    .Where(ap => ap.Id == id)
                    .FirstOrDefault();

            return agency;
        }

        public UserRating GetUserRating(string agencyId)
        {
            var up = this.db.UsersRatings
                .Include(a => a.Rating)
                .Where(u => u.RatingId == agencyId)
                .FirstOrDefault();

            return up;
        }
        public UserProfile GetUserByUsername(string username)
        {
            var user = this.db.UsersProfiles
                .Where(a => a.Username == username)
                .FirstOrDefault();

            return user;
        }
    }
}
