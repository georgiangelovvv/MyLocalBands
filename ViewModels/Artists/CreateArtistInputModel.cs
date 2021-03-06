using Microsoft.AspNetCore.Http;
using MyLocalBands.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Artists
{
    public class CreateArtistInputModel : BaseArtistInputModel
    {
        [Required]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [MaxFileSize(3)]
        public IFormFile Image { get; set; }
    }
}
