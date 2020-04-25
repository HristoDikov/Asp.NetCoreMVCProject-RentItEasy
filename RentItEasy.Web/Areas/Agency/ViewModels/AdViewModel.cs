using System.Collections.Generic;

namespace RentItEasy.Areas.Agency.ViewModels
{
    public class AdViewModel
    {
        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<MinimizedAdViewModel> MinimizedAds { get; set; }
    }
}
