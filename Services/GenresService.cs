using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MyLocalBands.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext db;

        public GenresService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            var allGenres = this.db.Genres.Select(x => new
            {
                x.Id,
                x.Name
            })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return allGenres;
        }

        public bool IsIdPresent(int id)
        {
            return this.db.Genres.Any(g => g.Id == id);
        }
    }
}
