namespace Saga.Orchestrator.Models
{
    public class OrderResponse
    {
        public string OrderId { get; internal set; }
        public bool Success { get; internal set; }
        public string Reason { get; internal set; }
    }
}
