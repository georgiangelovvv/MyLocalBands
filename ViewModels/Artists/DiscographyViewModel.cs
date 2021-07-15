using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocalBands.ViewModels.Artists
{
    public class DiscographyViewModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int SongsCount { get; set; }

        public int Year { get; set; }

        public int AlbumId { get; set; }
    }
}
