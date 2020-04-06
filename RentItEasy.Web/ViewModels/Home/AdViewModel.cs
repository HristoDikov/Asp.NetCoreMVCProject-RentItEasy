namespace RentItEasy.Web.ViewModels.Home
{
    public class AdViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CountOfVisits { get; set; }

        public string PropertyType { get; set; }

        public int Size { get; set; }

        public string Location { get; set; }

        public decimal RentPrice { get; set; }

        public byte[] Image { get; set; }

        public string BuildingClass { get; set; }
    }
}