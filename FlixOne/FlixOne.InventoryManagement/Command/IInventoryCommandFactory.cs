namespace FlixOne.InventoryManagement.Command;

public interface IInventoryCommandFactory
{
    InventoryCommand GetCommand(string input);
}
