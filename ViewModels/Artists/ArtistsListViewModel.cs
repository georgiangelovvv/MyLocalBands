using System;
using System.Collections.Generic;

namespace MyLocalBands.ViewModels.Artists
{
    public class ArtistsListViewModel
    {
        public IEnumerable<ArtistInListViewModel> Artists { get; set; }

        public int ArtistsCount { get; set; }

        public int PageNumber { get; set; }

        public int ItemsPerPage { get; set; }

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.ArtistsCount / this.ItemsPerPage);

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;
    }
}
