using Newtonsoft.Json;
using Saga.Orchestrator.Models;
using System.Text;

namespace Saga.Orchestrator
{
    public class InventoryProxy: IInventoryProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InventoryProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(int, bool)> UpdateInventory(Order order)
        {
            try
            {
                var request = JsonConvert.SerializeObject(order); 
                var inventoryClient = _httpClientFactory.CreateClient("Inventory");
                var inventoryResponse = await inventoryClient.PostAsync("/api/inventory", new StringContent(request, Encoding.UTF8, "application/JSON"));
                if (inventoryResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(inventoryResponse.ReasonPhrase);
                }
                var inventoryId = await inventoryResponse.Content.ReadAsStringAsync();

                return (Convert.ToInt32(inventoryId), true);
            }
            catch (Exception)
            {
                return (-1, false);
            }
        }

        public void Delete()
        {
            Console.WriteLine("Inventory deleted");
        }
    }
}
