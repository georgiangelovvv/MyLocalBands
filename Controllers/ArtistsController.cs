using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Artists;
using System.Collections.Generic;

namespace MyLocalBands.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ICountriesService countriesService;
        private readonly IGenresService genresService;
        private readonly IArtistStatusesService artistStatusesService;

        public ArtistsController(ICountriesService countriesService,
                                 IGenresService genresService, 
                                 IArtistStatusesService artistStatusesService)
        {
            this.countriesService = countriesService;
            this.genresService = genresService;
            this.artistStatusesService = artistStatusesService;
        }

        public IActionResult Create()
        {
            var inputModel = new CreateArtistInputModel();
            inputModel.Countries = this.countriesService.GetAll();
            inputModel.Genres = this.genresService.GetAll();
            inputModel.ArtistStatuses = this.artistStatusesService.GetAll();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(CreateArtistInputModel input)
        {
            if (!this.ModelState.IsValid) 
            {
                input.Countries = this.countriesService.GetAll();
                input.Genres = this.genresService.GetAll();
                input.ArtistStatuses = this.artistStatusesService.GetAll();
                return this.View(input);
            }

            return this.Redirect("/");
        }
    }
}
