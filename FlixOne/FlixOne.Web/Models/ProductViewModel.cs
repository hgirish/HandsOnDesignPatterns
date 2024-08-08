namespace FlixOne.Web.Models;

public class ProductViewModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }= string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImage { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
}