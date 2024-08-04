using FlixOne.InventoryManagement.Models;
using System.Collections.Concurrent;

namespace FlixOne.InventoryManagement.Repository;
internal class InventoryContext : IInventoryContext
{
    private readonly IDictionary<string, Book> _books;
    private static object _locker = new object();
    protected InventoryContext()
    {
        _books = new ConcurrentDictionary<string, Book>();
    }
    private static InventoryContext? _context;
    public static InventoryContext Singleton
    {
        get
        {
            if (_context == null)
            {
                lock (_locker)
                {
                    if (_context == null)
                    {
                        _context = new InventoryContext();
                    }
                   
                }
            }
            return _context;
        }
    }
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
