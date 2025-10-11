using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Core.Configurations
{
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> entity)
        {
            entity.HasKey(e => e.TranslationId)
                  .HasName("PK__Translat__663DA0ACE6F6B643");

            entity.Property(e => e.TranslationId).HasColumnName("TranslationID");

            entity.Property(e => e.EntityId)
                  .HasColumnName("EntityID");

            entity.Property(e => e.EntityName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.FieldName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.LanguageCode)
                  .IsRequired()
                  .HasMaxLength(5);

            entity.Property(e => e.TranslatedText)
                  .IsRequired();
        }
    }
}
