namespace RentItEasy.Services.Contracts
{
    using RentItEasy.Data.Models;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task CreateUser(string username, string firstName, string lastName, string email, string phoneNumber, string password);

        Task CreateAgency(string username,string description, string name, string email, string address, string phoneNumber, string password);

        Task CreateRole(string roleName, Account user);

        Task<string> Login(string email, string password, bool rememberMe);

        Task Logout();
    }
}
