using CRUD.Entities;
using static System.Net.WebRequestMethods;

namespace CRUD.Infrastructure;

public class DatabaseInitializer
{
    private readonly IApplicationDBContext _context;
    private readonly IWebHostEnvironment _env;


	public DatabaseInitializer(IApplicationDBContext context,IWebHostEnvironment env)
	{
		_context = context;
        _env = env;
	}

	public async Task SeedProductsData()
	{
        Console.Write(_env.WebRootPath);
        var Products = new List<Product>()
        {
            new Product()
            {

                Name = "Camera",
                ImagePath = "/images/camera.jpeg",
                Description = "Lorem Ipsum",
                Price = 20,
                Quantity = 2,
                IsDiscountApplicable = false,
                IsActive = true

            },
            new Product()
            {
                Name = "Lens",
                ImagePath = "/images/lens.jpeg",
                Description = "Lorem Ipsum 2",
                Price = 40,
                Quantity = 5,
                IsDiscountApplicable = false,
                IsActive = true
                        
            },
            new Product()
            {
                Name = "Coke",
                ImagePath =  "/images/coke.jpeg",
                Description = "Lorem Ipsum 3",
                Price = 1000,
                Quantity = 1,
                IsDiscountApplicable = true,
                PercentDiscount = 10,
                IsActive = true

            },
             new Product()
             {
                Name = "Memory Card",
                ImagePath =  "/images/memorycard.jpeg",
                Description = "Lorem Ipsum 3",
                Price = 800,
                Quantity = 1,
                IsDiscountApplicable = true,
                PercentDiscount = 20,
                IsActive = true

            }
        };
        _context.Products.AddRange(Products);
        await _context.SaveChangesAsync();
    }
}
