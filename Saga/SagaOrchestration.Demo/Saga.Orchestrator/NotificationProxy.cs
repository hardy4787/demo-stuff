using Newtonsoft.Json;
using Saga.Orchestrator.Models;
using System.Text;

namespace Saga.Orchestrator
{
    public class NotificationProxy : INotificationProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(int, bool)> Send(Order order)
        {
            try
            {
                var request = JsonConvert.SerializeObject(order);
                var notificationClient = _httpClientFactory.CreateClient("Notifier");
                var notificationResponse = await notificationClient.PostAsync("/api/notifier", new StringContent(request, Encoding.UTF8, "application/JSON"));
                var notificationId = await notificationResponse.Content.ReadAsStringAsync();

                return (Convert.ToInt32(notificationId), true);
            }
            catch (Exception)
            {
                return (-1, false);
            }
        }
    }
}
