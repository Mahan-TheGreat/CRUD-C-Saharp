using CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure;

public class ApplicationDBContext: DbContext, IApplicationDBContext
{
	public ApplicationDBContext(DbContextOptions options): base(options)
	{

	}

	public DbSet<Product> Products => Set<Product>();
}
