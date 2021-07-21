using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyLocalBands.Services.Contracts
{
    public interface IAlbumTypesService
    {
        IEnumerable<SelectListItem> GetAll();

        bool IsIdPresent(int id);
    }
}
