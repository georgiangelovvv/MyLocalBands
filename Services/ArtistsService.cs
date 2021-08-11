using Microsoft.AspNetCore.Hosting;
using MyLocalBands.Data;
using MyLocalBands.Data.Models;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Artists;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocalBands.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public ArtistsService(
            ApplicationDbContext db,
            IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task CreateAsync(CreateArtistInputModel input, string userId)
        {
            var imageExtension = Path.GetExtension(input.Image.FileName).ToLower();
            var savingDirectory = $"{this.environment.WebRootPath}/img/artists/";

            var artist = new Artist
            {
                Name = input.Name,
                YearFormed = input.YearFormed,
                Biography = input.Biography,
                CurrentMembers = input.CurrentMembers,
                ArtistStatusId = input.ArtistStatusId,
                GenreId = input.GenreId,
                CountryId = input.CountryId,
                CreatedByUserId = userId,
                Picture = new ArtistImage
                {
                    Extension = imageExtension
                }
            };

            if (!Directory.Exists(savingDirectory))
            {
                Directory.CreateDirectory(savingDirectory);
            }

            var filePath = $"{savingDirectory}{artist.Picture.Id}{imageExtension}";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await input.Image.CopyToAsync(fileStream);
            }

            await this.db.Artists.AddAsync(artist);
            await this.db.SaveChangesAsync();

            input.ArtistId = artist.Id;
        }

        public IEnumerable<ArtistInListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var artists = this.db.Artists.OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ArtistInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryName = x.Country.Name,
                    GenreName = x.Genre.Name,
                    ImagePath = $"{x.Picture.Id}{x.Picture.Extension}"
                })
                .ToList();

            return artists;
        }

        public ArtistDetailsViewModel GetById(int id)
        {
            var artist = this.db.Artists.Where(a => a.Id == id)
                .Select(x => new ArtistDetailsViewModel
                {
                    Name = x.Name,
                    YearFormed = x.YearFormed,
                    CountryName = x.Country.Name,
                    Biography = x.Biography,
                    ArtistStatusName = x.ArtistStatus.Name,
                    GenreName = x.Genre.Name,
                    CurrentMembers = x.CurrentMembers,
                    ImagePath = $"{x.Picture.Id}{x.Picture.Extension}",
                    Albums = x.Albums
                    .OrderBy(y => y.ReleaseDate)
                    .Select(r => new DiscographyViewModel
                    {
                        Name = r.Name,
                        Type = r.AlbumType.Name,
                        Year = r.ReleaseDate.Year,
                        SongsCount = r.Songs.Count,
                        AlbumId = r.Id
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return artist;
        }

        public int GetCount()
        {
            return this.db.Artists.Count();
        }

        public string GetCreatedByUserId(int id)
        {
            return this.db.Artists.Where(a => a.Id == id).Select(x => x.CreatedByUserId).FirstOrDefault();
        }

        public string GetName(int id)
        {
            return this.db.Artists.Where(a => a.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public bool IsIdPresent(int id)
        {
            return this.db.Artists.Any(a => a.Id == id);
        }
    }
}
