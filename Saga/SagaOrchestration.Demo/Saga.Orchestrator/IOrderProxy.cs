using Saga.Orchestrator.Models;

namespace Saga.Orchestrator
{
    public interface IOrderProxy
    {
        Task DeleteOrder(int orderId);
        Task<(int, bool)> CreateOrder(Order order);
    }
}
