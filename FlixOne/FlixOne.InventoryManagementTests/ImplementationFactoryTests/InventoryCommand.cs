using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.ImplementationFactoryTests;

public abstract class InventoryCommand
{
    protected abstract string[] CommandStrings {get;}
    public virtual bool IsCommandFor(string input)
    {
        return CommandStrings.Contains(input.ToLower());
    }

}
public class QuitCommand : InventoryCommand
{
    protected override string[] CommandStrings => ["q", "quit"];
}
public class GetInventoryCommand : InventoryCommand
{
    protected override string[] CommandStrings => ["g", "getinventory"];
}

public class AddInventoryCommand : InventoryCommand
{
    protected override string[] CommandStrings => ["a", "addinventory"];
}

public class UpdateQuantityCommand : InventoryCommand
{
    protected override string[] CommandStrings => ["u", "updatequantity"];
}

public class HelpCommand : InventoryCommand
{
    protected override string[] CommandStrings => ["?"];
}
public class UnknownCommand: InventoryCommand
{
    protected override string[] CommandStrings => [];
    public override bool IsCommandFor(string input)
    {
        return true;
    }
}
