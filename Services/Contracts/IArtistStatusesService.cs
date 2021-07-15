using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyLocalBands.Services.Contracts
{
    public interface IArtistStatusesService
    {
        IEnumerable<SelectListItem> GetAll();

        bool IsIdPresent(int id);
    }
}
