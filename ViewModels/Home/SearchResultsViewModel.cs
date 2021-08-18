using System.Collections.Generic;

namespace MyLocalBands.ViewModels.Home
{
    public class SearchResultsViewModel
    {
        public IEnumerable<SearchArtistsViewModel> Artists { get; set; }

        public IEnumerable<SearchAlbumsViewModel> Albums { get; set; }

        public string Query { get; set; }
    }
}
