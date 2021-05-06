using Microsoft.AspNetCore.Mvc;
using MyLocalBands.ViewModels.Artists;

namespace MyLocalBands.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateArtistInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
