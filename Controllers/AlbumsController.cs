using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Albums;
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
            var album = this.albumsService.GetById(id);

            return this.View(album);
        }

        public IActionResult Create(int id)
        {
            var inputModel = new CreateAlbumInputModel();
            inputModel.ArtistName = this.artistsService.GetName(id);
            inputModel.AlbumTypes = this.albumTypesService.GetAll();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateAlbumInputModel input)
        {
            input.ArtistId = id;

            if (!this.albumTypesService.IsIdPresent(input.AlbumTypeId))
            {
                this.ModelState.AddModelError(nameof(input.AlbumTypeId), "Album type does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                input.ArtistName = this.artistsService.GetName(id);
                input.AlbumTypes = this.albumTypesService.GetAll();

                return this.View(input);
            }

            await this.albumsService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
