using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository
{
    public interface IInventoryReadContext
    {
        Book[] GetBooks();
        
    }
}