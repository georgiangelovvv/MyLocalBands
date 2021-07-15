using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MyLocalBands.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ApplicationDbContext db;

        public CountriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            var allCountries = this.db.Countries.Select(x => new
            {
                x.Id,
                x.Name
            })
                .ToList()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return allCountries;
        }

        public bool IsIdPresent(int id)
        {
            return this.db.Countries.Any(c => c.Id == id);
        }
    }
}
