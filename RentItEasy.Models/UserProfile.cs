namespace RentItEasy.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class UserProfile
    {
        public UserProfile()
        {
            this.Ads = new HashSet<Ad>();
            this.Appointments = new HashSet<Appointment>();
            this.Id = Guid.NewGuid().ToString();
            this.Ratings = new HashSet<UserRating>();
        }
        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string AccountId { get; set; }

        public virtual Account Account { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public ICollection<UserRating> Ratings { get; set; }

        public virtual IEnumerable<Ad> Ads { get; set; }
    }
}
