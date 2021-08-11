using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Artists
{
    public class CreateArtistInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Year of formation")]
        [CurrentYearRange(1960)]
        public int YearFormed { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 150, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Biography { get; set; }

        [Required]
        [Display(Name = "Current members / Last known lineup", Prompt = "e.g. First name Last name - instrument")]
        [StringLength(500, MinimumLength = 15, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string CurrentMembers { get; set; }

        [Required]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [MaxFileSize(3)]
        public IFormFile Image { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Status")]
        public int ArtistStatusId { get; set; }

        public int ArtistId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public IEnumerable<SelectListItem> ArtistStatuses { get; set; }
    }
}
