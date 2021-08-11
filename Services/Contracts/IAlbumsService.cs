using MyLocalBands.ViewModels.Albums;
using System.Threading.Tasks;

namespace MyLocalBands.Services.Contracts
{
    public interface IAlbumsService
    {
        Task CreateAsync(CreateAlbumInputModel input);

        AlbumDetailsViewModel GetById(int id);

        bool IsIdPresent(int id);
    }
}
