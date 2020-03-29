namespace AspNetCoreTemplate.Data.Models
{
    using System;

    using AspNetCoreTemplate.Data.Models.Enums;

    public class Property
    {
        public int PropertyId { get; set; }

        public PropertyType PropertyType { get; set; }

        public int Size { get; set; }

        public string Location { get; set; }

        public decimal RentPrice { get; set; }

        public BuildingClass BuildingClass { get; set; }
    }
}
