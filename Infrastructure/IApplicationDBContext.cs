using CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure;

public interface IApplicationDBContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
