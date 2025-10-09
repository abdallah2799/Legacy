using Core.Models; // adjust namespace to your models’ namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BranchTrackConfiguration : IEntityTypeConfiguration<BranchTrack>
    {
        public void Configure(EntityTypeBuilder<BranchTrack> entity)
        {
            entity.HasKey(bt => new { bt.BranchID, bt.TrackID });

            entity.HasOne(bt => bt.Branch)
                  .WithMany(b => b.BranchTracks)
                  .HasForeignKey(bt => bt.BranchID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(bt => bt.Track)
                  .WithMany(t => t.BranchTracks)
                  .HasForeignKey(bt => bt.TrackID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(bt => bt.Supervisor)
                  .WithMany() 
                  .HasForeignKey(bt => bt.SupervisorID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.ToTable("BranchTracks");
        }
    }
}
