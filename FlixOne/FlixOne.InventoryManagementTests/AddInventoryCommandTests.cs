using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests;

[TestClass]
public class AddInventoryCommandTests
{
    [TestMethod]
    public void AddInventoryCommand_Successful()
    {
        const string expectedBookName = "AddInventoryUnitTest";
        var expectedInterface = new Helpers.TestUserInterface(
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Enter name:", expectedBookName)
            },
            new List<string>(),
            new List<string>()
            );
        var context = new TestInventoryContext(
            new Dictionary<string, Book>
            {
                {"Gremlins", new Book{Id=1, Name="Gremlins", Quantity = 7} }
            });

        // create an instance of the command
        var command = new AddInventoryCommand(expectedInterface, context);

        // add a new book with parameter 'name'
        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, "AddInventory is not a terminating command");
        Assert.IsTrue(result.wasSuccessful, "AddInventory did not complete successfully");

        // verify the book was added with the given name with 0 quantity
        Assert.AreEqual(1, context.GetAddedBooks().Length, "AddInventory should have added one book");

        var newBook = context.GetAddedBooks().First();
        Assert.AreEqual(expectedBookName, newBook.Name, "AddInventory did not add book successfully");
    }
}
