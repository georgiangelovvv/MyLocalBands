using Microsoft.AspNetCore.Hosting;
using MyLocalBands.Data;
using MyLocalBands.Data.Models;
using MyLocalBands.Services.Contracts;
using MyLocalBands.ViewModels.Artists;
using System.IO;
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

        public async Task CreateAsync(CreateArtistInputModel input)
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
        }
    }
}
