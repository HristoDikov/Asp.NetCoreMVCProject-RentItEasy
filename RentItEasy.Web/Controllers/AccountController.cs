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
                model.Email, model.Number, model.Password);

            return this.View();
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
                model.Number, model.Password);

            return this.Redirect(GlobalConstants.homeUrl);
        }
    }
}
