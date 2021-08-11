using Microsoft.AspNetCore.Mvc;
using MyLocalBands.Services.Contracts;

namespace MyLocalBands.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly IErrorsService errorsService;

        public ErrorsController(IErrorsService errorsService)
        {
            this.errorsService = errorsService;
        }

        public IActionResult Display(int statusCode)
        {
            var errorViewModel = this.errorsService.Generate(statusCode);

            return View(errorViewModel);
        }
    }
}
