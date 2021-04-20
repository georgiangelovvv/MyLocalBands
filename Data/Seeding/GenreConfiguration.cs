using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLocalBands.Data.Models;

namespace MyLocalBands.Data.Seeding
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
            new Genre { Id = 1, Name = "Alternative" },
            new Genre { Id = 2, Name = "Blues" },
            new Genre { Id = 3, Name = "Classical" },
            new Genre { Id = 4, Name = "Country" },
            new Genre { Id = 5, Name = "Dance" },
            new Genre { Id = 6, Name = "Electronic" },
            new Genre { Id = 7, Name = "Hip-Hop / Rap" },
            new Genre { Id = 8, Name = "Jazz" },
            new Genre { Id = 9, Name = "Latin" },
            new Genre { Id = 10, Name = "Metal" },
            new Genre { Id = 11, Name = "Pop" },
            new Genre { Id = 12, Name = "R&B / Soul" },
            new Genre { Id = 13, Name = "Reggae" },
            new Genre { Id = 14, Name = "Rock" },
            new Genre { Id = 15, Name = "Folk" }
            );
        }
    }
}
