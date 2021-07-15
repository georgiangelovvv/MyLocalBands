using System.Collections.Generic;

namespace MyLocalBands.ViewModels.Artists
{
    public class ArtistDetailsViewModel
    {
        public string Name { get; set; }

        public int YearFormed { get; set; }

        public string CountryName { get; set; }

        public string GenreName { get; set; }

        public string ImagePath { get; set; }

        public string ArtistStatusName { get; set; }

        public string CurrentMembers { get; set; }

        public string Biography { get; set; }

        public IEnumerable<DiscographyViewModel> Albums { get; set; }
    }
}
