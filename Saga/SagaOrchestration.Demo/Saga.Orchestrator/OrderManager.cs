using Saga.Orchestrator.Models;

namespace Saga.Orchestrator
{
    public partial class OrderManager : IOrderManager
    {
        private readonly IOrderProxy _orderProxy;
        private readonly IInventoryProxy _inventoryProxy;
        private readonly INotificationProxy _notificationProxy;

        public OrderManager(IOrderProxy orderProxy, IInventoryProxy inventoryProxy, INotificationProxy notificationProxy)
        {
            _orderProxy = orderProxy;
            _inventoryProxy = inventoryProxy;
            _notificationProxy = notificationProxy;
        }

        public bool CreateOrder(Order input)
        {
            var orderStateMachine = new Stateless.StateMachine<OrderTransactionState, OrderAction>(OrderTransactionState.NotStarted);

            int orderId = -1;
            var isOrderSuccess = false;

            orderStateMachine.Configure(OrderTransactionState.NotStarted)
                .PermitDynamic(OrderAction.CreateOrder, () =>
                {
                    (orderId, isOrderSuccess) = _orderProxy.CreateOrder(input).Result;
                    return isOrderSuccess ? OrderTransactionState.OrderCreated : OrderTransactionState.OrderCreateFailed;
                });

            orderStateMachine.Configure(OrderTransactionState.OrderCreated)
                 .PermitDynamic(OrderAction.UpdateInventory, () =>
                 {
                     var (inventoryId, isSuccess) = _inventoryProxy.UpdateInventory(input).Result;
                     return isSuccess ? OrderTransactionState.InventoryUpdated : OrderTransactionState.InventoryUpdateFailed;
                 }).OnEntry(() => orderStateMachine.Fire(OrderAction.UpdateInventory));

            orderStateMachine.Configure(OrderTransactionState.InventoryUpdated)
                 .PermitDynamic(OrderAction.SendNotification, () =>
                 {
                     var (notificationId, isSuccess) = _notificationProxy.Send(input).Result;
                     return isSuccess ? OrderTransactionState.NotificationSent : OrderTransactionState.NotificationSendFailed;
                 }).OnEntry(() => orderStateMachine.Fire(OrderAction.SendNotification));

            orderStateMachine.Configure(OrderTransactionState.InventoryUpdateFailed)
                 .PermitDynamic(OrderAction.RollbackInventory, () =>
                 {
                     _inventoryProxy.Delete();
                     return OrderTransactionState.InventoryRolledback;
                 }).OnEntry(() => orderStateMachine.Fire(OrderAction.RollbackInventory));

            orderStateMachine.Configure(OrderTransactionState.InventoryRolledback)
                 .PermitDynamic(OrderAction.CancelOrder, () =>
                 {
                     _orderProxy.DeleteOrder(orderId);
                     return OrderTransactionState.OrderCancelled;
                 }).OnEntry(() => orderStateMachine.Fire(OrderAction.CancelOrder));

            orderStateMachine.Fire(OrderAction.CreateOrder);


            return orderStateMachine.State == OrderTransactionState.NotificationSent;
        }
    }
}
