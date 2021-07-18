using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;

namespace MyLocalBands.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public IActionResult ById(int id)
        {
            var album = this.albumsService.GetById(id);

            return this.View(album);
        }
    }
}
