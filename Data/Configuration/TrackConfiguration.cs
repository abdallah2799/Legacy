using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> entity)
        {
            entity.HasKey(t => t.TrackId).HasName("PK__Tracks__7A74F8C01EF50B60");

            entity.Property(t => t.TrackId).HasColumnName("TrackID");
            

            entity.Property(t => t.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(t => t.Description)
                  .HasMaxLength(500);

            entity.Property(t => t.CreatedAt)
                  .HasDefaultValueSql("(getdate())")
                  .HasColumnType("datetime");

            entity.Property(t => t.UpdatedAt)
                  .HasDefaultValueSql("(getdate())")
                  .HasColumnType("datetime");
        }
    }
}
