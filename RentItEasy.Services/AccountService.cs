namespace RentItEasy.Services.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using RentItEasy.Data;
    using RentItEasy.Models;
    using System.Threading.Tasks;

    public class AccountService : IAccountService
    {
        private ApplicationDbContext db;
        private UserManager<Account> userManager;

        public AccountService(ApplicationDbContext db, UserManager<Account> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task CreateUser(string username, string firstName, string lastName, string email,
            int phoneNumber, string password)
        {
            var userProfile = new UserProfile
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Number = phoneNumber,
            };

            var user = new Account
            {
                UserProfile = userProfile,
                UserId = userProfile.Id,
            };

            var result = await userManager.CreateAsync(user, password);

            userProfile.AccountId = user.Id;
            userProfile.Account = user;
            db.Accounts.AddAsync(user);
            db.UsersProfiles.AddAsync(userProfile);
            db.SaveChanges();
        }
    }
}

