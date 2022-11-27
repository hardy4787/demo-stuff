using Saga.Orchestrator.Models;

namespace Saga.Orchestrator
{
    public interface IOrderManager
    {
        public bool CreateOrder(Order input);
    }
}
