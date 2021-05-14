using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Artists
{
    public class CreateArtistInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [CustomCurrentYearRange(1960)]
        public int YearFormed { get; set; }

        [Required]
        [MinLength(150)]
        public string Biography { get; set; }

        public string Picture { get; set; }

        public string Logo { get; set; }

        public int CountryId { get; set; }

        public int GenreId { get; set; }

        public int ArtistStatusId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public IEnumerable<SelectListItem> ArtistStatuses { get; set; }


    }
}
