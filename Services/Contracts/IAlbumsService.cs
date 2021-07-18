using MyLocalBands.ViewModels.Albums;

namespace MyLocalBands.Services.Contracts
{
    public interface IAlbumsService
    {
        AlbumDetailsViewModel GetById(int id);
    }
}
