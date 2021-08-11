using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Artists;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLocalBands.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ICountriesService countriesService;
        private readonly IGenresService genresService;
        private readonly IArtistStatusesService artistStatusesService;
        private readonly IArtistsService artistsService;

        public ArtistsController(
            ICountriesService countriesService,
            IGenresService genresService,
            IArtistStatusesService artistStatusesService,
            IArtistsService artistsService)
        {
            this.countriesService = countriesService;
            this.genresService = genresService;
            this.artistStatusesService = artistStatusesService;
            this.artistsService = artistsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var inputModel = new CreateArtistInputModel();
            inputModel.Countries = this.countriesService.GetAll();
            inputModel.Genres = this.genresService.GetAll();
            inputModel.ArtistStatuses = this.artistStatusesService.GetAll();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArtistInputModel input)
        {
            if (!this.countriesService.IsIdPresent(input.CountryId))
            {
                this.ModelState.AddModelError(nameof(input.CountryId), "Country does not exist.");
            }

            if (!this.genresService.IsIdPresent(input.GenreId))
            {
                this.ModelState.AddModelError(nameof(input.GenreId), "Genre does not exist.");
            }

            if (!this.artistStatusesService.IsIdPresent(input.ArtistStatusId))
            {
                this.ModelState.AddModelError(nameof(input.ArtistStatusId), "Status does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                input.Countries = this.countriesService.GetAll();
                input.Genres = this.genresService.GetAll();
                input.ArtistStatuses = this.artistStatusesService.GetAll();
                return this.View(input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.artistsService.CreateAsync(input, userId);

            var artistId = input.ArtistId;

            return this.RedirectToAction(nameof(this.ById), new { id = artistId });
        }

        public IActionResult All(int id = 1)
        {
            if (id < 1)
            {
                return this.StatusCode(404);
            }

            var itemsPerPage = 12;

            var viewModel = new ArtistsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ArtistsCount = this.artistsService.GetCount(),
                Artists = this.artistsService.GetAll(id, itemsPerPage)
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (!this.artistsService.IsIdPresent(id))
            {
                return this.StatusCode(404);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdByUserId = this.artistsService.GetCreatedByUserId(id);

            var artist = this.artistsService.GetById(id);
            artist.ArtistId = id;
            artist.IsCreatorUserLogged = userId == createdByUserId;

            return this.View(artist);
        }
    }
}
