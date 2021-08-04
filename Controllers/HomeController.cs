using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyLocalBands.Services;
using MyLocalBands.ViewModels;
using MyLocalBands.ViewModels.Albums;
using System.Diagnostics;

namespace MyLocalBands.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IGetCountsService countsService;

        public HomeController(ILogger<HomeController> logger, IGetCountsService countsService)
        {
            this.logger = logger;
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.countsService.GetCounts();
            return View(viewModel);
        }

        public IActionResult Privacy(CreateAlbumInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
