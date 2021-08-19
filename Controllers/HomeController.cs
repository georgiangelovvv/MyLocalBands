using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels;
using System.Diagnostics;

namespace MyLocalBands.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetCountsService countsService;
        private readonly ISearchService searchService;
        private readonly IAlbumsService albumsService;

        public HomeController(IGetCountsService countsService,
                              ISearchService searchService,
                              IAlbumsService albumsService)
        {
            this.countsService = countsService;
            this.searchService = searchService;
            this.albumsService = albumsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.countsService.GetCounts();
            viewModel.RandomAlbums = this.albumsService.GetRandom(9);
            return View(viewModel);
        }

        public IActionResult Search(string query)
        {
            var viewModel = this.searchService.Find(query);
            viewModel.Query = query;
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
