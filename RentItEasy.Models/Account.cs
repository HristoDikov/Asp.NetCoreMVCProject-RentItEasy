namespace RentItEasy.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using RentItEasy.Models.Contracts;

    public class Account : IdentityUser, IAccount
    {
        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public bool IsUserProfile { get; set; }

        public string AgencyProfileId { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
