namespace FlixOne.Web.Models;

public class Category
{
    public Category()
    {
        Products = new List<Product>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }=string.Empty;
    public virtual IEnumerable<Product> Products
    {
        get;
        set;
    }
}