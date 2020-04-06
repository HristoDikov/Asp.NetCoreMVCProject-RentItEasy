namespace RentItEasy.Services
{
    using AspNetCoreTemplate.Data.Models;
    using RentItEasy.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class AdService : IAdService
    {
        private readonly ApplicationDbContext db;

        public AdService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Ad> GetTenOfMostVisitedAds()
        {
            var ads = this.db.Ads.Select(a => new Ad
            {
                Title = a.Title,
                Description = a.Description,
                CountOfVisits = a.CountOfVisits,
                Property = a.Property

            }).Where(ad => ad.CountOfVisits >= 10)
                .ToList();

            return ads;
        }
    }
}
