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
        private readonly ApplicationDbContext db;
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(ApplicationDbContext db, UserManager<Account> userManager,
            SignInManager<Account> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task CreateUser(string username, string firstName, string lastName, string email,
            string phoneNumber, string password)
        {
            var userProfile = new UserProfile
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
            };

            var account = new Account
            {
                UserName = username,
                Email = email,
                UserProfileId = userProfile.Id,
                UserProfile = userProfile,
                PhoneNumber = userProfile.PhoneNumber,
            };

            var result = await userManager.CreateAsync(account, password);

            if (result.Succeeded)
            {
                await CreateRole(GlobalConstants.userRoleName, account);

                userProfile.AccountId = account.Id;
                userProfile.Account = account;

                await db.SaveChangesAsync();
            }
        }
        public async Task CreateRole(string roleName, Account user)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                var createRole = await roleManager.CreateAsync(role);

                if (createRole.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                    return;
                }
            }

            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CreateAgency(string username, string description, string name, string email, string address, string phoneNumber, string password)
        {
            var rating = new Rating();

            var agencyProfile = new AgencyProfile
            {
                Username = username,
                Address = address,
                PhoneNumber = phoneNumber,
                Rating = rating,
                Name = name,
                Description = description,
            };

            var account = new Account
            {
                AgencyProfileId = agencyProfile.Id,
                AgencyProfile = agencyProfile,
                UserName = username,
                Email = email,
            };
            
            var result = await userManager.CreateAsync(account, password);

            if (result.Succeeded)
            {
                await CreateRole(GlobalConstants.agencyRoleName, account);
                agencyProfile.AccountId = account.Id;
                agencyProfile.Account = account;

                await db.SaveChangesAsync();
            }
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

        public bool CheckIfUsernameIsAvailable(string username) 
        {
            var existingUsername = this.db.Accounts
                .Where(a => a.UserName == username)
                .Select(a => a.UserName)
                .FirstOrDefault();

            if (existingUsername != null)
            {
                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            await this.signInManager.SignOutAsync();
        }

    }
}

