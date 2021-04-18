using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocalBands.Data.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TrackNumber { get; set; }

        public TimeSpan Length { get; set; }

        public string YouTubeVideoLinkId { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
