using CRUD.Entities;
using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private ApplicationDBContext _Context;
    public ProductsController(ApplicationDBContext Context)
    {
        _Context = Context;
    }
    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        return await _Context.Products.ToListAsync();
    }
}
