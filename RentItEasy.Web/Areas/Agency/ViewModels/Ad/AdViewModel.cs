namespace RentItEasy.Areas.Agency.Ad.ViewModels
{
    using System.Collections.Generic;

    public class AdViewModel
    {
        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<MinimizedAdViewModel> MinimizedAds { get; set; }
    }
}
