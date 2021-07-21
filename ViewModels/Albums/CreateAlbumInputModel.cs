using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLocalBands.ViewModels.Albums
{
    public class CreateAlbumInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release date")]
        [ReleaseDateYearRange(1960, 2)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Prompt = "e.g. First name Last name - instrument")]
        [StringLength(500, MinimumLength = 15, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Lineup { get; set; }

        [JsonIgnore]                        // D E L E T E   M E
        [Required]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [MaxFileSize(2)]
        public IFormFile Artwork { get; set; }

        [Display(Name = "Album type")]
        public int AlbumTypeId { get; set; }

        public IEnumerable<SelectListItem> AlbumTypes { get; set; }

        public IEnumerable<SongInputModel> Songs { get; set; }
    }
}
