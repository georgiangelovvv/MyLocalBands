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

        public EditArtistInputModel GetEditInformation(int id)
        {
            var artist = this.db.Artists.Where(a => a.Id == id)
                .Select(x => new EditArtistInputModel
                {
                    Name = x.Name,
                    YearFormed = x.YearFormed,
                    Biography = x.Biography,
                    CurrentMembers = x.CurrentMembers,
                    CountryId = x.CountryId,
                    GenreId = x.GenreId,
                    ArtistStatusId = x.ArtistStatusId
                })
                .FirstOrDefault();

            return artist;
        }

        public async Task UpdateAsync(int id, EditArtistInputModel input)
        {
            var artist = this.db.Artists.Where(a => a.Id == id).FirstOrDefault();

            if (input.Image != null)
            {
                var artistImage = this.db.ArtistImages.Where(a => a.ArtistId == id).FirstOrDefault();
                var newImageExtension = Path.GetExtension(input.Image.FileName).ToLower();
                var savingDirectory = $"{this.environment.WebRootPath}/img/artists/";
                var oldImagePath = $"{savingDirectory}{artistImage.Id}{artistImage.Extension}";
                var imageId = artistImage.Id;

                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }

                var filePath = $"{savingDirectory}{imageId}{newImageExtension}";

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await input.Image.CopyToAsync(fileStream);
                }

                artistImage.Extension = newImageExtension;
            }

            artist.Name = input.Name;
            artist.YearFormed = input.YearFormed;
            artist.Biography = input.Biography;
            artist.CurrentMembers = input.CurrentMembers;
            artist.CountryId = input.CountryId;
            artist.GenreId = input.GenreId;
            artist.ArtistStatusId = input.ArtistStatusId;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var artist = this.db.Artists.Where(a => a.Id == id).FirstOrDefault();
            var artistImageFileName = this.db.ArtistImages.Where(a => a.ArtistId == id).Select(x => $"{x.Id}{x.Extension}").FirstOrDefault();
            var allAlbumIds = this.db.Albums.Where(a => a.ArtistId == id).Select(x => x.Id).ToList();
            var allArtworkFileNames = this.db.AlbumArtworks.Where(a => allAlbumIds.Contains(a.AlbumId)).Select(x => $"{x.Id}{x.Extension}").ToList();
            this.db.Artists.Remove(artist);
            var rowsAffected = await this.db.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                var artistImageDirectory = $"{this.environment.WebRootPath}/img/artists/{artistImageFileName}";

                if (File.Exists(artistImageDirectory))
                {
                    File.Delete(artistImageDirectory);
                }

                foreach (var artworkFileName in allArtworkFileNames)
                {
                    var artworkDirectory = $"{this.environment.WebRootPath}/img/albums/{artworkFileName}";

                    if (File.Exists(artworkDirectory))
                    {
                        File.Delete(artworkDirectory);
                    }
                }
            }
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
