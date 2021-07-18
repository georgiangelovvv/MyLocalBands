using System;
using System.Collections.Generic;

namespace MyLocalBands.ViewModels.Albums
{
    public class AlbumDetailsViewModel
    {
        public string Name { get; set; }

        public string ReleaseDate { get; set; }

        public string Type { get; set; }

        public string Lineup { get; set; }

        public string ImagePath { get; set; }

        public string ArtistName { get; set; }

        public int ArtistId { get; set; }

        public IEnumerable<TimeSpan> AllSongsLengths { get; set; }

        public TimeSpan TotalAlbumLength { get; set; }

        public IEnumerable<TracklistViewModel> Songs { get; set; }
    }
}
