using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagement.Command;

public abstract class InventoryCommand
{
    private readonly bool _isTerminatingCommand;

    internal InventoryCommand(bool commandIsTerminating,
        IUserInterface userInterface)
    {
        _isTerminatingCommand = commandIsTerminating;
        Interface = userInterface;
    }

    protected IUserInterface Interface { get; }

    public (bool wasSuccessful, bool shouldQuit) RunCommand()
    {
        if (this is IParameterisedCommand parameterisedCommand)
        {
            var allParametersCompleted = false;
            while (allParametersCompleted == false)
            {
                allParametersCompleted = parameterisedCommand.GetParameters();
            }
        }
        return (InternalCommand(), _isTerminatingCommand);
    }
    protected abstract bool InternalCommand();
    internal string? GetParameter(string parameterName)
    {
        return Interface.ReadValue($"Enter {parameterName}:");
    }

    public static 
        Func<IServiceProvider, Func<string, InventoryCommand>> 
        GetInventoryCommand => provider => input =>
    {
        IUserInterface userInterface = provider.GetService<IUserInterface>()!;
        switch (input.ToLower())
        {
            case "q":
            case "quit":
                return new QuitCommand(userInterface);
            case "a":
            case "addinventory":
                return new AddInventoryCommand(userInterface, provider.GetService<IInventoryWriteContext>()!);
            case "g":
            case "getinventory":
                return new GetInventoryCommand(userInterface, provider.GetService<IInventoryReadContext>()!);
            case "u":
            case "updatequantity":
                return new UpdateQuantityCommand(userInterface, provider.GetService<IInventoryWriteContext>()!);
            case "?":
                return new HelpCommand(userInterface);
            default:
                return new UnknownCommand(userInterface);
        }
    };
}
