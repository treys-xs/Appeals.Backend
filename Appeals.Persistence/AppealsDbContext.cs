using Microsoft.EntityFrameworkCore;
using Appeals.Domain;
using Appeals.Application.Interfaces;
using Appeals.Persistence.EntityTypeConfigurations;

namespace Appeals.Persistence
{
    public class AppealsDbContext : DbContext, IAppealsDbContext
    {
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<AppealType> AppealTypes { get; set; }

        public AppealsDbContext(DbContextOptions<AppealsDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppealConfiguration());
            builder.ApplyConfiguration(new AppealTypeConfiguration());
            base.OnModelCreating(builder); 
        }

    }
}
