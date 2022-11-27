using Saga.Orchestrator.Models;

namespace Saga.Orchestrator
{
    public interface IInventoryProxy
    {
        void Delete();
        Task<(int, bool)> UpdateInventory(Order order);
    }
}
