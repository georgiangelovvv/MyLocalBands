using System.Collections.Generic;

namespace MyLocalBands.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}
