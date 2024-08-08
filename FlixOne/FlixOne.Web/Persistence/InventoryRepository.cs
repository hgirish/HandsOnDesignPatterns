using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Persistence;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryContext _inventoryContext;

    public InventoryRepository(InventoryContext inventoryContext)
    {
        _inventoryContext = inventoryContext;
    }
    public bool AddCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public bool AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetCategories()
    {
        return _inventoryContext.Categories.ToList();
    }

    public Category GetCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _inventoryContext.Products.Include(c=>c.Category).ToList();
    }

    public bool RemoveCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}