using MyLocalBands.ViewModels.Artists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLocalBands.Services.Contracts
{
    public interface IArtistsService
    {
        Task CreateAsync(CreateArtistInputModel input);

        IEnumerable<ArtistInListViewModel> GetAll(int page, int itemsPerPage = 12);

        int GetCount();

        ArtistDetailsViewModel GetById(int id);
    }
}
