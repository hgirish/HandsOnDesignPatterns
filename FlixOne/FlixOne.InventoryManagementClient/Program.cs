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
    services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();

    services.AddSingleton<IInventoryContext, InventoryContext>();
}