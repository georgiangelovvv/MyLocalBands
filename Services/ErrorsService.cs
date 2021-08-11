using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Errors;

namespace MyLocalBands.Services
{
    public class ErrorsService : IErrorsService
    {
        public ErrorDetailsViewModel Generate(int statusCode)
        {
            var error = new ErrorDetailsViewModel();

            switch (statusCode)
            {
                case 403:
                    error.StatusCode = 403;
                    error.Title = "Access forbidden";
                    error.Description = "Unfortunately you do not have permission to view this page.";
                    break;
                case 404:
                    error.StatusCode = 404;
                    error.Title = "Page not found";
                    error.Description = "Sorry, but the page you are looking for was either not found or does not exist.";
                    break;
                case 500:
                    error.StatusCode = 500;
                    error.Title = "Internal server error";
                    error.Description = "Unfortunately we're having trouble loading the page you are looking for. Please come back in a while.";
                    break;
                case 502:
                    error.StatusCode = 502;
                    error.Title = "Bad gateway";
                    error.Description = "The server encountered a temporary error and could not complete your request.";
                    break;
                case 503:
                    error.StatusCode = 503;
                    error.Title = "Service unavailable";
                    error.Description = "The service you requested is not available at this time.";
                    break;
                default:
                    error.StatusCode = statusCode;
                    error.Title = "Something went wrong...";
                    error.Description = "We're working to fix this as soon as possible.";
                    break;
            }

            return error;
        }
    }
}
