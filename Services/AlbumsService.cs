using Microsoft.AspNetCore.Hosting;
using MyLocalBands.Data;
using MyLocalBands.Data.Models;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Albums;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLocalBands.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public AlbumsService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task CreateAsync(CreateAlbumInputModel input)
        {
            var imageExtension = Path.GetExtension(input.Artwork.FileName).ToLower();
            var savingDirectory = $"{this.environment.WebRootPath}/img/albums/";

            var album = new Album
            {
                ArtistId = input.ArtistId,
                Name = input.Name,
                ReleaseDate = (DateTime)input.ReleaseDate,
                Lineup = input.Lineup,
                AlbumTypeId = input.AlbumTypeId,
                Artwork = new AlbumArtwork
                {
                    Extension = imageExtension
                }
            };

            foreach (var inputSong in input.Songs)
            {
                var pattern = @"http(?:s)?:\/\/(?:m.)?(?:www\.)?youtu(?:\.be\/|be\.com\/(?:watch\?(?:feature=youtu.be\&)?v=|v\/|embed\/|user\/(?:[\w#]+\/)+))([^&#?\n]+)";
                var youtubeLinkMatch = Regex.Match(inputSong.YoutubeLink ?? "", pattern);
                var youtubeLinkId = youtubeLinkMatch.Groups[1].Value;

                var song = new Song
                {
                    TrackNumber = inputSong.TrackNumber,
                    Title = inputSong.Title,
                    Length = TimeSpan.FromSeconds((inputSong.Minutes * 60) + inputSong.Seconds)
                };

                if (!string.IsNullOrWhiteSpace(youtubeLinkId))
                {
                    song.YouTubeVideoLinkId = youtubeLinkId;
                }

                album.Songs.Add(song);
            }

            if (!Directory.Exists(savingDirectory))
            {
                Directory.CreateDirectory(savingDirectory);
            }

            var filePath = $"{savingDirectory}{album.Artwork.Id}{imageExtension}";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await input.Artwork.CopyToAsync(fileStream);
            }

            await this.db.Albums.AddAsync(album);
            await this.db.SaveChangesAsync();

            input.AlbumId = album.Id;
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
                        Length = s.Length,
                        YoutubeVideoLinkId = s.YouTubeVideoLinkId
                    })
                    .ToList()
                })
                .FirstOrDefault();

            album.TotalAlbumLength = TimeSpan.FromSeconds((int)album.AllSongsLengths.Sum(x => x.TotalSeconds));

            return album;
        }

        public bool IsIdPresent(int id)
        {
            return this.db.Albums.Any(a => a.Id == id);
        }
    }
}
