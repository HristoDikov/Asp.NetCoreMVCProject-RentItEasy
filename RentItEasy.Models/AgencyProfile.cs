namespace AspNetCoreTemplate.Data.Models
{
    using RentItEasy.Models;
    using RentItEasy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class AgencyProfile : IProfile
    {
        public AgencyProfile()
        {
            this.Ads = new HashSet<Ad>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }

        public string RatingId { get; set; }

        public Rating Rating { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string AccountId { get; set; }

        public Account Account { get; set; }

        public HashSet<Ad> Ads { get; set; }
    }
}
