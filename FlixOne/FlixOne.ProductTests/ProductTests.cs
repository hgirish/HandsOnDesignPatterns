using FlixOne.Web.Controllers;
using FlixOne.Web.Models;
using FlixOne.Web.Persistence;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FlixOne.ProductTests;

public class ProductTests
{
   
    [Fact]
    public void Get_Returns_ActionResults()
    {
        // Arrange
        var mockRepo = new Mock<IInventoryRepository>();
        mockRepo.Setup(repo =>
        repo.GetProducts())
            .Returns(new ProductData().GetProducts());

        var controller = new ProductController(mockRepo.Object);

        var result = controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
       var model =  Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Model);
        Assert.NotNull(model);
        Assert.Equal(2, model.Count());
    }
}
