using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyLocalBands.Data.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int YearFormed { get; set; }

        public string Biography { get; set; }

        public string CurrentMembers { get; set; }

        public int ArtistStatusId { get; set; }

        public ArtistStatus ArtistStatus { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string CreatedByUserId { get; set; }

        public IdentityUser CreatedByUser { get; set; }

        public ICollection<Album> Albums { get; set; }

        public ArtistImage Picture { get; set; }
    }
}
