namespace RentItEasy.Data.Models
{
    using RentItEasy.Models;
    using RentItEasy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class AgencyProfile
    {
        public AgencyProfile()
        {
            this.Ads = new HashSet<Ad>();
            this.Appointments = new HashSet<Appointment>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string RatingId { get; set; }

        public virtual Rating Rating { get; set; }

        public string AccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual HashSet<Ad> Ads { get; set; }

        public virtual HashSet<Appointment> Appointments { get; set; }
    }
}
