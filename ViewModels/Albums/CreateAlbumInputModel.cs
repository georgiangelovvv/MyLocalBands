using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Albums
{
    public class CreateAlbumInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ReleaseDateYearRange(1960, 2)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 15, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Lineup { get; set; }

        [Required]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [MaxFileSize(2)]
        public IFormFile Artwork { get; set; }

        public int AlbumTypeId { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public IEnumerable<SelectListItem> AlbumTypes { get; set; }

        [Required]
        public List<SongInputModel> Songs { get; set; }

        public int AlbumId { get; set; }
    }
}
