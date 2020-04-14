﻿namespace RentItEasy.Services
{
    using RentItEasy.Areas.User.ViewModels;
    using RentItEasy.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdService
    {
        IEnumerable<Ad> GetTenOfMostVisitedAds();

        Task CreateAd(string userName, string title, string description, IEnumerable<string> imagesPath,
            string propertyType, string size, string location, string rentPrice, string buildingClass);

        IEnumerable<AdViewModel> GetUserAds(string name);
    }
}
