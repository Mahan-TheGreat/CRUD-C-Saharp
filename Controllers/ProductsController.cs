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

    [HttpGet("GetProduct")]
    public async Task<List<Product>> GetProducts()
    {
        return await _Context.Products.ToListAsync();
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> PostProduct(Product p)
    {
        _Context.Products.Add(p);
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product Added SuccessFully"
        });
    }

    [HttpPut("EditProduct")]
    public async Task<IActionResult> EditProduct(int id, Product editedProduct)
    {
        var Product = await _Context.Products.FirstAsync(x => x.id == id);
        if(Product == null)
        {
            return BadRequest("Invalid id!");
        }
        Product.name = editedProduct.name;
        Product.description = editedProduct.description;
        Product.price = editedProduct.price;
        Product.quantity = editedProduct.quantity;
        Product.isDiscountApplicable= editedProduct.isDiscountApplicable;
        Product.isActive= editedProduct.isActive;
        if(editedProduct.percentDiscount != null)
        {
            Product.percentDiscount = editedProduct.percentDiscount;
        }

        _Context.Products.Update(Product);
        await _Context.SaveChangesAsync();

        return Ok(new
        {
            status = 200,
            message = "Product Edited SuccessFully"
        });
    }

    [HttpPut("disableProduct")]
    public async Task<IActionResult> DisableProduct(int id)
    {
        var Product = await _Context.Products.FirstAsync(x => x.id == id);
        if (Product == null)
        {
            return BadRequest("Invalid id!");
        }
        Product.isActive = false;
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product disabled SuccessFully"
        });

    }

    [HttpPut("enableProduct")]
    public async Task<IActionResult> EnableProduct(int id)
    {
        var Product = await _Context.Products.FirstAsync(x => x.id == id);
        if (Product == null)
        {
            return BadRequest("Invalid id!");
        }
        Product.isActive = true;
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product enabled SuccessFully"
        });

    }
}
