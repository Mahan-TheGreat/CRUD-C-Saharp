using CRUD.DTOs;
using CRUD.Entities;
using CRUD.Infrastructure;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDBContext _Context;

    private readonly IImageHelper _ImageHelper;
    public ProductsController(ApplicationDBContext Context, IImageHelper ImageHelper)
    {
        _Context = Context;
        _ImageHelper = ImageHelper;
    }

    [HttpGet("GetProduct")]
    public async Task<List<Product>> GetProducts()
    {
        return await _Context.Products.ToListAsync();
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> PostProduct(ProductDTO p)
    {
        var imagePath = _ImageHelper.SaveImage(p.ImagePath.FileName, p.ImagePath.Base64String, "products");
        Product p1 = new Product
        {
            Name = p.Name,
            Description = p.Description,
            ImagePath = imagePath,
            Price = p.Price,
            Quantity = p.Quantity,
            IsDiscountApplicable = p.IsDiscountApplicable,
            IsActive = true,

        };

        _Context.Products.Add(p1);
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product Added SuccessFully"
        });
    }

    [HttpPut("EditProduct/{id}")]
    public async Task<IActionResult> EditProduct(int id, ProductDTO editedProduct)
    {
        var Product = await _Context.Products.FirstAsync(x => x.Id == id);
        if(Product == null)
        {
            return BadRequest("Invalid id!");
        }
        var imagePath = editedProduct.ImagePath.FilePath;
        Product.Name = editedProduct.Name;
        Product.Description = editedProduct.Description;
        Product.Price = editedProduct.Price;
        Product.Quantity = editedProduct.Quantity;
        Product.IsDiscountApplicable= editedProduct.IsDiscountApplicable;
        Product.IsActive= editedProduct.IsActive;
        if(editedProduct.PercentDiscount != null)
        {
            Product.PercentDiscount = editedProduct.PercentDiscount;
        }
        var path = editedProduct.ImagePath;
        if (editedProduct.ImagePath.Base64String != "")
        {
            imagePath = _ImageHelper.SaveImage(path.FileName, path.Base64String, path.FilePath);
        }
        Product.ImagePath = imagePath;

        _Context.Products.Update(Product);
        await _Context.SaveChangesAsync();

        return Ok(new
        {
            status = 200,
            message = "Product Edited SuccessFully"
        });
    }

    [HttpPut("DisableProduct/{id}")]
    public async Task<IActionResult> DisableProduct(int id)
    {
        var Product = await _Context.Products.FirstAsync(x => x.Id == id);
        if (Product == null)
        {
            return BadRequest("Invalid id!");
        }
        Product.IsActive = false;
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product disabled SuccessFully"
        });

    }

    [HttpPut("EnableProduct/{id}")]
    public async Task<IActionResult> EnableProduct(int id)
    {
        var Product = await _Context.Products.FirstAsync(x => x.Id == id);
        if (Product == null)
        {
            return BadRequest("Invalid id!");
        }
        Product.IsActive = true;
        await _Context.SaveChangesAsync();
        return Ok(new
        {
            status = 200,
            message = "Product enabled SuccessFully"
        });

    }
}
