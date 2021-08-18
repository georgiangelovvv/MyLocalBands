using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Home;
using System.Linq;

namespace MyLocalBands.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext db;

        public SearchService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public SearchResultsViewModel Find(string query)
        {
            var searchResults = new SearchResultsViewModel
            {
                Artists = this.db.Artists
                .Where(a => a.Name.Contains(query))
                 .Select(x => new SearchArtistsViewModel
                 {
                     ArtistId = x.Id,
                     Name = x.Name,
                     ImagePath = $"{x.Picture.Id}{x.Picture.Extension}"
                 })
                 .ToList(),
                Albums = this.db.Albums
                .Where(a => a.Name.Contains(query))
                .Select(x => new SearchAlbumsViewModel
                {
                    AlbumId = x.Id,
                    Name = x.Name,
                    ImagePath = $"{x.Artwork.Id}{x.Artwork.Extension}"
                })
                .ToList()
            };

            return searchResults;
        }
    }
}
