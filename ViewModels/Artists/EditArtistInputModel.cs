using Microsoft.AspNetCore.Http;
using MyLocalBands.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.ViewModels.Artists
{
    public class EditArtistInputModel : BaseArtistInputModel
    {
        public int Id { get; set; }

        
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" }, true)]
        [MaxFileSize(3, true)]
        public IFormFile Image { get; set; }
    }
}
