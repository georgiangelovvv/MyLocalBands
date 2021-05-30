using MyLocalBands.ViewModels.Artists;
using System.Threading.Tasks;

namespace MyLocalBands.Services.Contracts
{
    public interface IArtistsService
    {
        Task CreateAsync(CreateArtistInputModel input);
    }
}
