﻿namespace RentItEasy.Areas.User.ViewModels
{
    public class MinimizedAgencyProfile
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string MinimizedDescription
        {
            get => Description.Length > 20
                   ? Description.Substring(0, 15) + "..."
                   : Description;
        }

        public string Name { get; set; }

        public string Rating { get; set; }
    }
}
