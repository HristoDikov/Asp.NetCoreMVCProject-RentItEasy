using RentItEasy.Data.Models;

namespace RentItEasy.Areas.User.ViewModels
{
    public class AgencyProfileViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Rating Rating { get; set; }

        public decimal RateDigit { get; set; }
    }
}
