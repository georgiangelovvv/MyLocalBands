using MyLocalBands.ViewModels.Home;

namespace MyLocalBands.Services.Contracts
{
    public interface ISearchService
    {
        SearchResultsViewModel Find(string query);
    }
}
