namespace RentItEasy.Services
{
    using RentItEasy.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdService
    {
        IEnumerable<Ad> GetSixAds();

        IEnumerable<Ad> GetAllAds(int? take = null, int skip = 0);

        int GetAdsCount();

        int GetAdsByAgencyCount(string username);


        Task CreateAd(string userName, string title, string description, IEnumerable<string> imagesPath,
            string propertyType, string size, string location, string rentPrice, string buildingClass);

        IEnumerable<Ad> GetAgencyAds(string name, int? take = null, int skip = 0);

        Ad GetAd(int id);

        Task EditAd(int id, string title, string description, string propertyType,
            string size, string location, string rentPrice, string buildingClass);

        Task DeleteAd(int id);
    }
}
