using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLocalBands.Data.Models;

namespace MyLocalBands.Data.Seeding
{
    public class ArtistStatusConfiguration : IEntityTypeConfiguration<ArtistStatus>
    {
        public void Configure(EntityTypeBuilder<ArtistStatus> builder)
        {
            builder.HasData(
                new ArtistStatus { Id = 1, Name = "Active" },
                new ArtistStatus { Id = 2, Name = "Split-up" },
                new ArtistStatus { Id = 3, Name = "On hold" },
                new ArtistStatus { Id = 4, Name = "Changed name" },
                new ArtistStatus { Id = 5, Name = "Unknown" }
                );
        }
    }
}
