namespace RentItEasy.Services.Contracts
{
    using System.Threading.Tasks;
    public interface IAccountService
    {
        Task CreateUser(string username, string firstName, string lastName, string email, int phoneNumber, string password);

        Task CreateAgency(string username, string email, string address, int phoneNumber, string password);
    }
}
