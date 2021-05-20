using System;

namespace MyLocalBands.Data.Models
{
    public class AlbumArtwork
    {
        public AlbumArtwork()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Extension { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
