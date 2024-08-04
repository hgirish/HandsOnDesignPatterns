using FlixOne.InventoryManagement.Models;
using System.Collections.Concurrent;

namespace FlixOne.InventoryManagement.Repository;
public class InventoryContext : IInventoryContext
{
    private readonly IDictionary<string, Book> _books;
    private static object _locker = new object();
    public InventoryContext()
    {
        _books = new ConcurrentDictionary<string, Book>();
    }
    private static InventoryContext? _context;
   
    public bool AddBook(string name)
    {
        _books.Add(name, new Book { Name = name });
        return true;
    }

    public Book[] GetBooks()
    {
        return _books.Values.ToArray();
    }

    public bool UpdateQuantity(string name, int quantity)
    {
        lock (_locker)
        {
            _books[name].Quantity += quantity;
        }
        return true;
    }
}
