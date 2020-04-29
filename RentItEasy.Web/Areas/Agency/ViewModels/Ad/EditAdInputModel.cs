namespace RentItEasy.Areas.Agency.Ad.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditAdInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        public string Size { get; set; }

        public string Location { get; set; }

        [Display(Name = "Rent Price")]
        public string RentPrice { get; set; }

        [Display(Name = "Building Class")]
        public string BuildingClass { get; set; }
    }
}
