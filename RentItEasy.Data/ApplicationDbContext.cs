using AspNetCoreTemplate.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentItEasy.Models;

namespace RentItEasy.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<AgencyProfile> AgenciesProfiles { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<UserProfile> UsersProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>()
                   .HasOne(a => a.AgencyProfile)
                   .WithOne(c => c.Account)
                   .HasForeignKey<AgencyProfile>(c => c.AccountId);

            builder.Entity<Account>()
                   .HasOne(a => a.UserProfile)
                   .WithOne(u => u.Account)
                   .HasForeignKey<UserProfile>(u => u.AccountId);
        }
    }
}
