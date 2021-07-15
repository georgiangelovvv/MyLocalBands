using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyLocalBands.Services.Contracts
{
    public interface IGenresService
    {
        IEnumerable<SelectListItem> GetAll();

        bool IsIdPresent(int id);
    }
}
