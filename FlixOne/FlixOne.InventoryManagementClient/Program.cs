using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using FlixOne.InventoryManagementClient;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();

ConfigureServices(services);

IServiceProvider serviceProvider = services.BuildServiceProvider();
var service = serviceProvider.GetService<ICatalogService>();
service?.Run();


Console.WriteLine("CatalogService  has completed.");



static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IUserInterface, ConsoleUserInterface>();
    services.AddTransient<ICatalogService, CatalogService>();
    services.AddTransient<Func<string, InventoryCommand>>(InventoryCommand.GetInventoryCommand);


    var context = new InventoryContext();
    services.AddSingleton<IInventoryReadContext, IInventoryReadContext>(p => context);
    services.AddSingleton<IInventoryWriteContext, IInventoryWriteContext>(p => context);
    services.AddSingleton<IInventoryContext, InventoryContext>(p => context);

}