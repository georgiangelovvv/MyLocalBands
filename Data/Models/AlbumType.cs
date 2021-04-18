using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocalBands.Data.Models
{
    public class AlbumType
    {
        public AlbumType()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
