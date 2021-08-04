using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Albums
{
    public class SongInputModel
    {
        [Required]
        [Range(1, 99)]
        public int TrackNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Title { get; set; }

        [Required]
        [Range(0, 59)]
        public int Minutes { get; set; }

        [Required]
        [Range(0, 59)]
        public int Seconds { get; set; }

        [MaxLength(70, ErrorMessage = "{0} can have a max of {1} characters")]
        public string YoutubeLink { get; set; }
    }
}
