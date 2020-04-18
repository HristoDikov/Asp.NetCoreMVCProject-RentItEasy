using RentItEasy.Data.Models;
using System;
using System.Threading.Tasks;

namespace RentItEasy.Services.Contracts
{
    public interface IAppointmentService
    {
        void Create(Ad ad, UserProfile userProfile,AgencyProfile agencyProfile, DateTime date);
    }
}
