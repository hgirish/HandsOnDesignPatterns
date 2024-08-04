using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command;

internal class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryContext _context;

    public AddInventoryCommand(
        IUserInterface userInterface,
        IInventoryContext context) :
        base( userInterface)
    {
        _context = context;
    }

    public string? InventoryName { get; private set; }

    public bool GetParameters()
    {
        if (string.IsNullOrWhiteSpace(InventoryName))
        {
            InventoryName = GetParameter("name");

        }
        return !string.IsNullOrWhiteSpace(InventoryName);
    }

    internal override bool InternalCommand()
    {
        return _context.AddBook(InventoryName!);
    }
}
