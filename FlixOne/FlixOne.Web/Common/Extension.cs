using FlixOne.Web.Models;

namespace FlixOne.Web.Common;

public static class Extension
{
    public static ProductViewModel ToProductvm(this Product product)
    {
        return new ProductViewModel
        {
            CategoryDescription = product.Category.Description,
            CategoryId = product.Category.Id,
            CategoryName = product.Category.Name,
            ProductDescription = product.Description,
            ProductId = product.Id,
            ProductName = product.Name,
            ProductPrice = product.Price,
            ProductImage = product.Image,
        };
    }

    public static IEnumerable<ProductViewModel> ToProductvm(
        this IEnumerable<Product> products) => 
        products.Select(ToProductvm).ToList();
}
