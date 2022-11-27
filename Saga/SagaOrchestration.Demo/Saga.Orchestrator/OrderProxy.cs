using Newtonsoft.Json;
using Saga.Orchestrator.Models;
using System.Text;

namespace Saga.Orchestrator
{
    public class OrderProxy: IOrderProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(int, bool)> CreateOrder(Order order)
        {
            try
            {
                var request = JsonConvert.SerializeObject(order);
                // Create order
                var orderClient = _httpClientFactory.CreateClient("Order");
                var orderResponse = await orderClient.PostAsync("/api/order", new StringContent(request, Encoding.UTF8, "application/JSON"));
                var orderId = await orderResponse.Content.ReadAsStringAsync();
                return (Convert.ToInt32(orderId), true);
            }
            catch (Exception)
            {
                return (-1, false);
            }
        }

        public async Task DeleteOrder(int orderId)
        {
            var orderClient = _httpClientFactory.CreateClient("Order");
            await orderClient.DeleteAsync($"/api/order/{orderId}");
            Console.WriteLine($"Order deleted: {orderId}");
        }
    }
}
