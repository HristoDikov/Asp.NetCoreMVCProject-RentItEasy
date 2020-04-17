namespace RentItEasy.Areas.User.ViewModels
{
    using Data.Models;
    using Models.Enums;
    using System;
    using System.Collections.Generic;

    public class FullAdViewModel
    {
        public int Id { get;set; }

        public string MadeBy { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Location { get; set; }

        public string RentPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public PropertyType PropertyType { get; set; }

        public BuildingClass BuildingClass { get; set; }

        public IEnumerable<ImagePath> ImagesPaths { get; set; }
    }
}
