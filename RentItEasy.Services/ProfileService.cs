using RentItEasy.Data.Models;
namespace RentItEasy.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data;
    using RentItEasy.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext db;

        public ProfileService(ApplicationDbContext db)
        {
            this.db = db;
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
                    .Where(ap => ap.Id == id)
                    .FirstOrDefault();

            return agency; 
        }
    }
}
