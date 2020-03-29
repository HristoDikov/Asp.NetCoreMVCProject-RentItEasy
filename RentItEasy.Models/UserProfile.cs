namespace RentItEasy.Models
{
    using AspNetCoreTemplate.Data.Models;
    using RentItEasy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class UserProfile : IProfile
    {
        public UserProfile()
        {
            this.Ads = new HashSet<Ad>();
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Number { get; set; }

        public string AccountId { get; set; }

        public Account Account { get; set; }

        public string RatingId { get; set; }

        public Rating Rating { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public HashSet<Ad> Ads { get; set; }
    }
}
