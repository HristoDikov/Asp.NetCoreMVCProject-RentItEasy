namespace RentItEasy.Services
{
    using AspNetCoreTemplate.Data.Models;
    using System.Collections.Generic;

    public interface IAdService
    {
       IEnumerable<Ad> GetTenOfMostVisitedAds(); 
    }
}
