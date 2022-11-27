using Saga.Orchestrator.Models;

namespace Saga.Orchestrator
{
    public interface INotificationProxy
    {
        public Task<(int, bool)> Send(Order order);
    }
}
