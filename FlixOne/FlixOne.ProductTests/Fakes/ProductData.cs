using FlixOne.Web.Models;

public class ProductData
{
    public IEnumerable<Product> GetProducts()
    {
        var category1 = new Category
        {
            Id = Guid.NewGuid(),
            Description = "Category Description",
            Name = "Category Name"
        };
        var productVm = new List<Product>()
            {
                new Product
                {
                    Category = category1,                    
                    Description = "Product Description 1",
                    Id = Guid.NewGuid(),
                    Image = "Image full path 1",
                    Name = "Product Name 1",
                     Price = 112M,
                     CategoryId = category1.Id
                },                  
                new Product
                {
                    Category = category1,
                    Description = "Product Description 2",
                    Id = Guid.NewGuid(),
                    Image = "Image full path 2",
                    Name = "Product Name 2",
                     Price = 56M,
                     CategoryId = category1.Id
                },
            };
        return productVm;

    }
}