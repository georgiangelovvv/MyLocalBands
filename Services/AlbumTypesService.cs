using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MyLocalBands.Services
{
    public class AlbumTypesService : IAlbumTypesService
    {
        private readonly ApplicationDbContext db;

        public AlbumTypesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            var allAlbumTypes = this.db.AlbumTypes.Select(x => new
            {
                x.Id,
                x.Name
            })
               .ToList()
               .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return allAlbumTypes;
        }

        public bool IsIdPresent(int id)
        {
            return this.db.AlbumTypes.Any(a => a.Id == id);
        }
    }
}
