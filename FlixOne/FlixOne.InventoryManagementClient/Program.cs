

using System.Reflection;

Greeting();



// note: inline out variable introduced as part of C# 7.0
//GetCommand("?").RunCommand(out bool shouldQuit);



//while (!shouldQuit)
//{
//    // handle the commands
//}

Console.WriteLine("CatalogService  has completed.");

void Greeting()
{
    var version = Assembly.GetExecutingAssembly().GetName().Version;
    Console.WriteLine("***********************************");
    Console.WriteLine("*                                  *");
    Console.WriteLine("*     Welcome to FlixOne Inventory Management System");
    Console.WriteLine($"*                           v{version}       *");
    Console.WriteLine("***********************************");
    Console.WriteLine("");

}

object GetCommand(string v)
{
    throw new NotImplementedException();
}
