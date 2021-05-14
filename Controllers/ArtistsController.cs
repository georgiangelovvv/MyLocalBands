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
            var viewModel = new CreateArtistInputModel();
            viewModel.Countries = this.countriesService.GetAll();
            viewModel.Genres = this.genresService.GetAll();
            viewModel.ArtistStatuses = this.artistStatusesService.GetAll();
            return this.View(viewModel);
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
