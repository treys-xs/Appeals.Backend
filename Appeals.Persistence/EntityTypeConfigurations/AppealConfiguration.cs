using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Appeals.Domain;

namespace Appeals.Persistence.EntityTypeConfigurations
{
    public class AppealConfiguration : IEntityTypeConfiguration<Appeal>
    {
        public void Configure(EntityTypeBuilder<Appeal> builder)
        {
            builder.HasKey(appeal => appeal.Id);
            builder.HasIndex(appeal => appeal.Id).IsUnique();
            builder.HasOne(appeal => appeal.Type)
                   .WithMany(type => type.Appeals);
            builder.Property(appeal => appeal.Message).HasMaxLength(250);
            builder.Property(appeal => appeal.PhoneNumber).HasMaxLength(11);
        }
    }
}
