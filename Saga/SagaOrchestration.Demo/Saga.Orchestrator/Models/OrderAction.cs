namespace Saga.Orchestrator
{
    public enum OrderAction
    {
        CreateOrder,
        CancelOrder,
        UpdateInventory,
        RollbackInventory,
        SendNotification,
        RetryNotification
    }
}
