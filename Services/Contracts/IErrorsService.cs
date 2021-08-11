using MyLocalBands.ViewModels.Errors;

namespace MyLocalBands.Services.Contracts
{
    public interface IErrorsService
    {
        ErrorDetailsViewModel Generate(int statusCode);
    }
}
