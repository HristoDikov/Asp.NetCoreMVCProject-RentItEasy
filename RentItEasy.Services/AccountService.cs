namespace RentItEasy.Services.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using RentItEasy.Common;
    using RentItEasy.Data;
    using RentItEasy.Data.Models;
    using System.Linq;
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
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Rating = rating,
            };

            var account = new Account
            {
                UserName = username,
                Email = email,
                UserProfileId = userProfile.Id,
                UserProfile = userProfile,
                PhoneNumber = userProfile.PhoneNumber,
                IsUserProfile = true,
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
                Username = username,
                Address = address,
                PhoneNumber = phoneNumber,
                Rating = rating,
            };

            var user = new Account
            {
                AgencyProfileId = agencyProfile.Id,
                AgencyProfile = agencyProfile,
                UserName = username,
                Email = email,
                IsUserProfile = false,
            };
            
            await userManager.CreateAsync(user, password);

            agencyProfile.AccountId = user.Id;
            agencyProfile.Account = user;

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

        public async Task Logout()
        {
            await this.signInManager.SignOutAsync();
        }

        public UserProfile GetUserByUsername(string username) 
        {
            var user = this.db.UsersProfiles
                .Where(a => a.Username == username)
                .FirstOrDefault();

            return user;
        }
        public AgencyProfile GetAgencyByUsername(string id)
        {
            var agency = this.db.AgenciesProfiles
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return agency;
        }
    }
}

