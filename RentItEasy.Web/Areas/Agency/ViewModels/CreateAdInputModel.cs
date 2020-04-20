namespace RentItEasy.Areas.User.ViewModels
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using global::RentItEasy.Models.Enums;
    using System.Collections.Generic;

    public class CreateAdInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<IFormFile> Images { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        public string Size { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Rent Price")]
        public string RentPrice { get; set; }

        [Display(Name = "Building Class")]
        public string BuildingClass { get; set; }
    }
}
