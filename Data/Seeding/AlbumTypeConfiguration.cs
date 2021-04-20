using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLocalBands.Data.Models;

namespace MyLocalBands.Data.Seeding
{
    public class AlbumTypeConfiguration : IEntityTypeConfiguration<AlbumType>
    {
        public void Configure(EntityTypeBuilder<AlbumType> builder)
        {
            builder.HasData(
                new AlbumType { Id = 1, Name = "Demo" },
                new AlbumType { Id = 2, Name = "Single" },
                new AlbumType { Id = 3, Name = "EP" },
                new AlbumType { Id = 4, Name = "Compilation" },
                new AlbumType { Id = 5, Name = "Live album" },
                new AlbumType { Id = 6, Name = "Full-length" },
                new AlbumType { Id = 7, Name = "Video" }
            );
        }
    }
}
