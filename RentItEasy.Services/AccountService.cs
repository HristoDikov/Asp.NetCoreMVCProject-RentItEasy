namespace RentItEasy.Services.Contracts
{
    using AspNetCoreTemplate.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using RentItEasy.Common;
    using RentItEasy.Data;
    using RentItEasy.Models;
    using System.Threading.Tasks;

    public class AccountService : IAccountService
    {
        private ApplicationDbContext db;
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;

        public AccountService(ApplicationDbContext db, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task CreateUser(string username, string firstName, string lastName, string email,
            string phoneNumber, string password)
        {
            var rating = new Rating();

            var userProfile = new UserProfile
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Rating = rating,
            };

            var account = new Account
            {
                UserName = username,
                Email = email,
                UserId = userProfile.Id,
                UserProfile = userProfile,
            };

            var result = await userManager.CreateAsync(account, password);

            userProfile.AccountId = account.Id;
            userProfile.Account = account;

            await db.SaveChangesAsync();
        }


        public async Task CreateAgency(string username, string email, string address, string phoneNumber, string password)
        {
            var rating = new Rating();

            var agencyProfile = new AgencyProfile
            {
                Address = address,
                PhoneNumber = phoneNumber,
                Rating = rating,
            };

            var user = new Account
            {
                AgencyId = agencyProfile.Id,
                AgencyProfile = agencyProfile,
                UserName = username,
                Email = email,
            };
            
            await userManager.CreateAsync(user, password);

            agencyProfile.AccountId = user.Id;
            agencyProfile.Account = user;

            await db.AgenciesProfiles.AddAsync(agencyProfile);
            await db.Accounts.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task<string> Login(string email, string password, bool rememberMe)
        {
            var loggingSuccessful = await signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);

            if (loggingSuccessful.Succeeded)
            {
                return GlobalConstants.homeUrl;
            }

            return GlobalConstants.loginUrl;
        }
    }
}

