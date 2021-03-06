﻿namespace  RentItEasy.Areas.Agency.Ad.ViewModels
{
    using global::RentItEasy.Data.Models;
    using global::RentItEasy.Models.Enums;
    using System.Collections.Generic;

    public class FullAdViewModel
    {
        public int Id { get; set; }

        public string MadeBy { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Location { get; set; }

        public string RentPrice { get; set; }

        public string CreatedOn { get; set; }

        public PropertyType PropertyType { get; set; }

        public BuildingClass BuildingClass { get; set; }

        public IEnumerable<ImagePath> ImagesPaths { get; set; }
    }
}
