namespace RentItEasy.Services.Contracts
{
    using System.Threading.Tasks;
    public interface IAccountService
    {
        Task CreateUser(string username, string firstName, string lastName, string email, string phoneNumber, string password);

        Task CreateAgency(string username, string email, string address, string phoneNumber, string password);

        Task<string> Login(string email, string password, bool rememberMe);
    }
}
