using RentItEasy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentItEasy.Services.Contracts
{
    public interface IProfileService
    {
        IEnumerable<AgencyProfile> GetAgencies();

        AgencyProfile GetAgencyById(string id);

        UserProfile GetUserByUsername(string username);

        void Rate(UserProfile userProfile, AgencyProfile agencyProfile, decimal rateDigit);

        UserRating GetUserRating(string agencyId);
    }
}
