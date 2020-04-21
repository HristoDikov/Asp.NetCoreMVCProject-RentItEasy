namespace RentItEasy.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<UserRating> UsersRatings { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<ImagePath> ImagesPaths { get; set; }

        public DbSet<AgencyProfile> AgenciesProfiles { get; set; }

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
