using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Artists
{
    public class CreateArtistInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int YearFormed { get; set; }

        [Required]
        [MinLength(150)]
        public string Biography { get; set; }

        public string Picture { get; set; }

        public string Logo { get; set; }
    }
}
