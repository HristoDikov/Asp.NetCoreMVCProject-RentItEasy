namespace RentItEasy.Models
{
    using AspNetCoreTemplate.Data.Models;
    using RentItEasy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class UserProfile
    {
        public UserProfile()
        {
            this.Ads = new HashSet<Ad>();
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string AccountId { get; set; }

        public virtual Account Account { get; set; }

        public string RatingId { get; set; }

        public virtual Rating Rating { get; set; }

        public virtual HashSet<Ad> Ads { get; set; }
    }
}
