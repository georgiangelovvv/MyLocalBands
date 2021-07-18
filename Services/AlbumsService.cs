using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Albums;
using System;
using System.Globalization;
using System.Linq;

namespace MyLocalBands.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public AlbumDetailsViewModel GetById(int id)
        {
            var album = this.db.Albums.Where(a => a.Id == id)
                .Select(x => new AlbumDetailsViewModel
                {
                    Name = x.Name,
                    Type = x.AlbumType.Name,
                    ReleaseDate = x.ReleaseDate.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Lineup = x.Lineup,
                    ImagePath = $"{x.Artwork.Id}{x.Artwork.Extension}",
                    ArtistName = x.Artist.Name,
                    ArtistId = x.ArtistId,
                    AllSongsLengths = x.Songs.Select(s => s.Length).ToList(),
                    Songs = x.Songs
                    .OrderBy(x => x.TrackNumber)
                    .Select(s => new TracklistViewModel
                    {
                        TrackNumber = s.TrackNumber,
                        Title = s.Title,
                        Length = s.Length
                    })
                    .ToList()
                })
                .FirstOrDefault();

            album.TotalAlbumLength = TimeSpan.FromSeconds((int)album.AllSongsLengths.Sum(x => x.TotalSeconds));

            return album;
        }
    }
}
