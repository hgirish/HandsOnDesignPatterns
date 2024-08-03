namespace FlixOne.InventoryManagement;

public class Class1
{

}
internal class HelpCommand : NonTerminatingCommand
{
    public HelpCommand(IUserInterface userInterface) : base(userInterface)
    {
    }

    internal override bool InternalCommand()
    {
        Console.WriteLine("USAGE: ");
        Console.WriteLine("\taddinventory (a)");
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine();

        return true;
    }
}
internal class QuitCommand : InventoryCommand
{
    internal QuitCommand(IUserInterface userInterface) :
        base(commandIsTerminating: true, userInterface: userInterface)
    {

    }

    internal override bool InternalCommand()
    {
        Interface.WriteMessage("Thank you for using FlixOne Inventory Management System.");
        return true;
    }
}

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

internal abstract class NonTerminatingCommand : InventoryCommand
{
    protected NonTerminatingCommand(IUserInterface userInterface) :
        base(commandIsTerminating: false, userInterface)
    { }
}

public class ConsoleUserInterface : IUserInterface
{
    // read value from  console
    public string? ReadValue(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    // message to the console
    public void WriteMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
    }

    // writer warning message to the console
    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
    }
}

public interface IParameterisedCommand
{
    bool GetParameters();
}

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

public interface IUserInterface : IReadUserInterface, IWriteUserInterface
{  
    
}
public interface IReadUserInterface
{
    string? ReadValue(string message);
}

public interface IWriteUserInterface
{
    void WriteMessage(string message);
    void WriteWarning(string message);
}