using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Core.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> entity)
        {
            entity.HasKey(e => e.LogId)
                  .HasName("PK__Logs__5E5499A83430A1B2");

            entity.Property(e => e.LogId).HasColumnName("LogID");

            entity.Property(e => e.Level)
                  .HasMaxLength(50);

            entity.Property(e => e.Timestamp)
                  .HasDefaultValueSql("(getdate())")
                  .HasColumnType("datetime");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User)
                  .WithMany(p => p.Logs)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK_Logs_User");
        }
    }
}
