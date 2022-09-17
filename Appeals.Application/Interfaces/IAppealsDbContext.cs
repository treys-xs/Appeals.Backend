using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Appeals.Domain;

namespace Appeals.Application.Interfaces
{
    public interface IAppealsDbContext
    {
        DbSet<Appeal> Appeals { get; set; }
        DbSet<AppealType> AppealTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
