namespace CRUD.Entities;

public class Product
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public decimal price { get; set; }
    public int quantity { get; set; }
    public bool isDiscountApplicable { get; set; }
    public decimal percentDiscount { get; set;}
    public decimal priceDiscount { get; set; }
    public bool isActive { get; set; }
}
