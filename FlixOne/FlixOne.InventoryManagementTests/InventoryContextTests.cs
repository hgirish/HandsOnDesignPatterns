using FlixOne.InventoryManagement.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementTests;
[TestClass]
public class InventoryContextTests
{
    ServiceProvider Services { get; set; }
    [TestInitialize]
    public void Startup()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<IInventoryContext, InventoryContext>();
        Services = services.BuildServiceProvider();
    }
    private IInventoryContext GetInventoryContext()
    {
        
        return Services.GetService<IInventoryContext>();
    }
    [TestMethod]
    public void MaintainBooks_Successful()
    {
        List<Task> tasks = new List<Task>();
        var context = GetInventoryContext();

        // add thirty books
        foreach (var id in Enumerable.Range(1, 30))
        {
            
            tasks.Add(AddBook($"Book_{id}"));
        }
        Task.WaitAll(tasks.ToArray());
        tasks.Clear();

        // let's update the quantity of the books by adding 1,2,3,4,5...
        foreach (var quantity in Enumerable.Range(1, 10))
        {
            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(UpdateQuantity($"Book_{id}", quantity));
            }
        }
        // let's update quantity of books by subtracting 1,2,3,4,5..,
        foreach (var quantity in Enumerable.Range(1, 10))
        {
            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(UpdateQuantity($"Book_{id}", -quantity));
            }
        }
        Task.WaitAll(tasks.ToArray());
        //tasks.Clear();

        // all quantities should be zero
        foreach (var book in context.GetBooks())
        {
            Assert.AreEqual(0, book.Quantity);
        }
        
    }

    public Task AddBook(string book)
    {
        return Task.Run(() =>
        {
            var context = GetInventoryContext();
            Assert.IsTrue(context.AddBook(book));
        });
    }
    public Task UpdateQuantity(string book, int quantity)
    {
        return Task.Run(() =>
    {
        var context = GetInventoryContext();
        Assert.IsTrue(context.UpdateQuantity(book, quantity));
    });
    }
}
