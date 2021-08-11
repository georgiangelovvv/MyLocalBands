using System;

namespace MyLocalBands.ViewModels.Albums
{
    public class TracklistViewModel
    {
        public int TrackNumber { get; set; }

        public string Title { get; set; }

        public TimeSpan Length { get; set; }

        public string YoutubeVideoLinkId { get; set; }
    }
}
