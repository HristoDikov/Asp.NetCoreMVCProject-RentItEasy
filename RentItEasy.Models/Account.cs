namespace RentItEasy.Models
{
    using AspNetCoreTemplate.Data.Models;
    using System;
    using Microsoft.AspNetCore.Identity;
    using RentItEasy.Models.Contracts;

    public class Account : IdentityUser, IAccount
    {
        public string UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public string AgencyId { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
