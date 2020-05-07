namespace RentItEasy.Data.Models
{
    using System;

    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public virtual Ad Ad { get; set; }

        public int AdId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public string UserProfileId { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }

        public string AgencyProfileId { get; set; }

    }
}
