using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository;

public interface IInventoryContext
{
    Book[] GetBooks();
    bool AddBook(string name);
    bool UpdateQuantity(string name, int quantity);
}
