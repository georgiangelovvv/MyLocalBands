using Microsoft.AspNetCore.Mvc.Rendering;
using MyLocalBands.Data;
using MyLocalBands.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MyLocalBands.Services
{
    public class ArtistStatusesService : IArtistStatusesService
    {
        private readonly ApplicationDbContext db;

        public ArtistStatusesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SelectListItem> GetAll()
        {
            var allArtistStatuses = this.db.ArtistStatuses.Select(x => new
            {
                x.Id,
                x.Name
            })
               .ToList()
               .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return allArtistStatuses;
        }
    }
}
