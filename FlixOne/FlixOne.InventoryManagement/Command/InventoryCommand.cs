using FlixOne.InventoryManagement.UserInterface;

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
    internal abstract bool InternalCommand();
    internal string? GetParameter(string parameterName)
    {
        return Interface.ReadValue($"Enter {parameterName}:");
    }
}
