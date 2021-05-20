using System;

namespace MyLocalBands.Data.Models
{
    public class ArtistImage
    {
        public ArtistImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Extension { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}
