using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyLocalBands.Services.Contracts
{
    public interface ICountriesService
    {
        IEnumerable<SelectListItem> GetAll();

        bool IsIdPresent(int id);
    }
}
