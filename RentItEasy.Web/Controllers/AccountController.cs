namespace RentItEasy.Controllers
{
    using global::RentItEasy.Common;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using RentItEasy.Web.ViewModels.Account;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index() 
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult RegisterUser() 
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterAsUserInputModel model) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.accountService.CreateUser(model.Username, model.FirstName, model.LastName, 
                model.Email, model.PhoneNumber, model.Password);

            return this.Redirect(GlobalConstants.homeUrl);
        }

        [HttpGet]
        public IActionResult RegisterAgency()
        {
            return this.View();
        }

        [HttpPost]

        public async Task<IActionResult> RegisterAgency(RegisterAsAgencyInputModel model) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await accountService.CreateAgency(model.Username, model.Email, model.Address,
                model.PhoneNumber, model.Password);

            return this.Redirect(GlobalConstants.homeUrl);
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return this.View();
        }

        public IActionResult Login(LoginInputModel model) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var url =  this.accountService.Login(model.Username, model.Password, model.RememberMe).Result;

            return this.View();
        }
    }
}
