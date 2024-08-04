using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command;

public class AddInventoryCommand : InventoryCommand, IParameterisedCommand
{
    public AddInventoryCommand(bool commandIsTerminating,
        IUserInterface userInterface) :
        base(commandIsTerminating, userInterface)
    {
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
        throw new NotImplementedException();
    }
}
