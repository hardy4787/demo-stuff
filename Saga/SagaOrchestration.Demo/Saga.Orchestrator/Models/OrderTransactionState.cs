namespace Saga.Orchestrator
{
    public enum OrderTransactionState
    {
        NotStarted,
        OrderCreated,
        OrderCancelled,
        OrderCreateFailed,
        InventoryUpdated,
        InventoryUpdateFailed,
        InventoryRolledback,
        NotificationSent,
        NotificationSendFailed
    }

}
