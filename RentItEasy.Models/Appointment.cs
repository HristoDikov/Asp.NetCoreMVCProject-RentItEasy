using System;

namespace RentItEasy.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public virtual Ad Ad { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }
    }
}
