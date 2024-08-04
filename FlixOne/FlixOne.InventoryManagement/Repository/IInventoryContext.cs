using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository;

internal interface IInventoryContext
{
    Book[] GetBooks();
    bool AddBook(string name);
    bool UpdateQuantity(string name, int quantity);
}
