namespace CRUD.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ImageDTO ImagePath { get; set; } = new ImageDTO();
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } 
    public int Quantity { get; set; }
    public bool IsDiscountApplicable { get; set; }
    public decimal? PercentDiscount { get; set; }
    public bool IsActive { get; set; }
}
