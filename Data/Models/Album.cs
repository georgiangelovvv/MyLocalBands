using System;
using System.Collections.Generic;

namespace MyLocalBands.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Cover { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int AlbumTypeId { get; set; }

        public AlbumType AlbumType { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
