namespace RentItEasy.Models
{
    using AspNetCoreTemplate.Data.Models;
    using System;
    using Microsoft.AspNetCore.Identity;

    public class Account : IdentityUser
    {
        public string UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public string AgencyId { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }
    }
}
