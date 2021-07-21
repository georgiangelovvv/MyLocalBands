using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Albums;

namespace MyLocalBands.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;
        private readonly IAlbumTypesService albumTypesService;

        public AlbumsController(IAlbumsService albumsService, 
                                IAlbumTypesService albumTypesService)
        {
            this.albumsService = albumsService;
            this.albumTypesService = albumTypesService;
        }

        public IActionResult ById(int id)
        {
            var album = this.albumsService.GetById(id);

            return this.View(album);
        }

        public IActionResult Create(int id)
        {
            var inputModel = new CreateAlbumInputModel();
            inputModel.AlbumTypes = this.albumTypesService.GetAll();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAlbumInputModel input)
        {
            if (!this.albumTypesService.IsIdPresent(input.AlbumTypeId))
            {
                this.ModelState.AddModelError(nameof(input.AlbumTypeId), "Album type does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                input.AlbumTypes = this.albumTypesService.GetAll();

                return this.View(input);
            }

            //return this.Redirect("/");
            return this.Json(input);
        }
    }
}
