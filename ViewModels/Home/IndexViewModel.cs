using System.Collections.Generic;

namespace MyLocalBands.ViewModels.Home
{
    public class IndexViewModel
    {
        public int ArtistsCount { get; set; }

        public int AlbumsCount { get; set; }

        public int SongsCount { get; set; }

        public IEnumerable<IndexPageAlbumsViewModel> RandomAlbums { get; set; }
    }
}
