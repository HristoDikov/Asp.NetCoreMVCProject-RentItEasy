namespace RentItEasy.Services
{
    using RentItEasy.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdService
    {
        IEnumerable<Ad> GetTenOfMostVisitedAds();

        Task CreateAd(string userName, string title, string description, IEnumerable<string> imagesPath,
            string propertyType, string size, string location, string rentPrice, string buildingClass);

        IEnumerable<Ad> GetAgencyAds(string name);

        Ad GetAd(int id);

        Task EditAd(int id, string title, string description, string propertyType,
            string size, string location, string rentPrice, string buildingClass);

        Task DeleteAd(int id);
    }
}
