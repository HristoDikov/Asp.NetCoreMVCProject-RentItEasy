namespace RentItEasy.Data.Models
{
    using RentItEasy.Models.Enums;
    using System.Collections.Generic;

    public class Ad
    {
        public Ad()
        {
            this.ImagesPaths = new HashSet<ImagePath>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Location { get; set; }

        public string RentPrice { get; set; }

        public PropertyType PropertyType { get; set; }

        public BuildingClass BuildingClass { get; set; }

        public string UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public string AgencyProfileId { get; set; }
        public AgencyProfile AgencyProfile { get; set; }

        public virtual IEnumerable<ImagePath> ImagesPaths { get; set; }
    }
}
