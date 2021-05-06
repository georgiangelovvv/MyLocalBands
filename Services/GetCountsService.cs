using MyLocalBands.Data;
using MyLocalBands.ViewModels.Home;
using System.Linq;

namespace MyLocalBands.Services
{
    public class GetCountsService : IGetCountsService
    {
        private readonly ApplicationDbContext db;

        public GetCountsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IndexViewModel GetCounts()
        {
            var indexData = new IndexViewModel
            {
                ArtistsCount = this.db.Artists.Count(),
                AlbumsCount = this.db.Albums.Count(),
                SongsCount = this.db.Songs.Count()
            };

            return indexData;
        }
    }
}
