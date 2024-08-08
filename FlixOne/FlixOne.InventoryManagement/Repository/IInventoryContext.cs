using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository;

public interface IInventoryContext
    : IInventoryReadContext, IInventoryWriteContext
{
   
}
