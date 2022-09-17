using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Appeals.Domain;

namespace Appeals.Persistence.EntityTypeConfigurations
{
    public class AppealTypeConfiguration : IEntityTypeConfiguration<AppealType>
    {
        public void Configure(EntityTypeBuilder<AppealType> builder)
        {
            builder.HasKey(appeal => appeal.Id);
            builder.HasIndex(appeal => appeal.Id).IsUnique();
            builder.HasMany(type => type.Appeals)
                   .WithOne(appeal => appeal.Type);
        }
    }
}
