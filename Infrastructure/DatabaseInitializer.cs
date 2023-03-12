using CRUD.Entities;

namespace CRUD.Infrastructure;

public class DatabaseInitializer
{
    public readonly IApplicationDBContext _context;

	public DatabaseInitializer(IApplicationDBContext context)
	{
		_context = context;
	}

	public async Task SeedProductsData()
	{
        var Products = new List<Product>()
        {
            new Product()
            {
                name = "Product1",
                description = "Lorem Ipsum",
                price = 20,
                quantity = 2,
                isDiscountApplicable = false,
                isActive = true

            },
            new Product()
            {
                name = "Product2",
                description = "Lorem Ipsum 2",
                price = 40,
                quantity = 5,
                isDiscountApplicable = false,
                isActive = true

            },
            new Product()
            {
                name = "Product 3",
                description = "Lorem Ipsum 3",
                price = 1000,
                quantity = 1,
                isDiscountApplicable = true,
                percentDiscount = 10,
                priceDiscount = 100,
                isActive = true

            }
        };
        _context.Products.AddRange(Products);
        await _context.SaveChangesAsync();
    }
}
