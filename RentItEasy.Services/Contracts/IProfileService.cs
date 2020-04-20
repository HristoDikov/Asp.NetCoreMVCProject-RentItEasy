using RentItEasy.Data.Models;
using System.Collections.Generic;

namespace RentItEasy.Services.Contracts
{
    public interface IProfileService
    {
        IEnumerable<AgencyProfile> GetAgencies();

        AgencyProfile GetAgencyById(string id);
    }
}
