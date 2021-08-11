using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Albums;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLocalBands.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;
        private readonly IAlbumTypesService albumTypesService;
        private readonly IArtistsService artistsService;

        public AlbumsController(IAlbumsService albumsService,
                                IAlbumTypesService albumTypesService,
                                IArtistsService artistsService)
        {
            this.albumsService = albumsService;
            this.albumTypesService = albumTypesService;
            this.artistsService = artistsService;
        }

        public IActionResult ById(int id)
        {
            if (!this.albumsService.IsIdPresent(id))
            {
                return this.StatusCode(404);
            }

            var albumViewModel = this.albumsService.GetById(id);

            return this.View(albumViewModel);
        }

        [Route("/Albums/Create/{artistId}")]
        public IActionResult Create(int artistId)
        {
            if (!this.artistsService.IsIdPresent(artistId))
            {
                return this.StatusCode(404);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdByUserId = this.artistsService.GetCreatedByUserId(artistId);

            if (userId == null || userId != createdByUserId)
            {
                return this.StatusCode(403);
            }

            var inputModel = new CreateAlbumInputModel();
            inputModel.ArtistName = this.artistsService.GetName(artistId);
            inputModel.AlbumTypes = this.albumTypesService.GetAll();
            return this.View(inputModel);
        }

        [HttpPost]
        [Route("/Albums/Create/{artistId}")]
        public async Task<IActionResult> Create(int artistId, CreateAlbumInputModel input)
        {
            if (!this.artistsService.IsIdPresent(artistId))
            {
                return this.StatusCode(404);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdByUserId = this.artistsService.GetCreatedByUserId(artistId);

            if (userId == null || userId != createdByUserId)
            {
                return this.StatusCode(403);
            }

            input.ArtistId = artistId;

            if (!this.albumTypesService.IsIdPresent(input.AlbumTypeId))
            {
                this.ModelState.AddModelError(nameof(input.AlbumTypeId), "Album type does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                input.ArtistName = this.artistsService.GetName(artistId);
                input.AlbumTypes = this.albumTypesService.GetAll();

                return this.View(input);
            }

            await this.albumsService.CreateAsync(input);

            var albumId = input.AlbumId;

            return this.RedirectToAction(nameof(this.ById), new { id = albumId });
        }
    }
}
