namespace FlixOne.Web.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    public string Image { get; set; }=string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = new();
}
