using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Saga.Orchestrator.Models;
using System.Text;

namespace Saga.Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<OrderResponse> Post([FromBody] Order order)
        {
            var request = JsonConvert.SerializeObject(order);
            // Create order
            var orderClient = _httpClientFactory.CreateClient("Order");
            var orderResponse = await orderClient.PostAsync("/api/order", new StringContent(request, Encoding.UTF8, "application/JSON"));
            var orderId = await orderResponse.Content.ReadAsStringAsync();

            // Update inventory
            var inventoryId = string.Empty;
            try
            {
                var inventoryClient = _httpClientFactory.CreateClient("Inventory");
                var inventoryResponse = await inventoryClient.PostAsync("/api/inventory", new StringContent(request, Encoding.UTF8, "application/JSON"));
                if(inventoryResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(inventoryResponse.ReasonPhrase);
                }
                inventoryId = await inventoryResponse.Content.ReadAsStringAsync();
            }
            catch (Exception exception)
            {
                await orderClient.DeleteAsync($"/api/order/{orderId}");
                return new OrderResponse { Success = false, Reason = exception.Message };
            }

            // Send notification
            var notificationClient = _httpClientFactory.CreateClient("Notifier");
            var notificationResponse = await notificationClient.PostAsync("/api/notifier", new StringContent(request, Encoding.UTF8, "application/JSON"));
            var notificationId = await notificationResponse.Content.ReadAsStringAsync();

            Console.WriteLine($"Order: {orderId}, Inventory: {inventoryId}, Notification: {notificationId}");

            return new OrderResponse { OrderId = orderId, Success = true };
        }
    }
}
