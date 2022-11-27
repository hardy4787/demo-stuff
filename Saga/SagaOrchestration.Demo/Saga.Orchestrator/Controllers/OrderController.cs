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
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost]
        public OrderResponse Post([FromBody] Order order)
        {
            var response = _orderManager.CreateOrder(order);
            return new OrderResponse { Success = response };
        }
    }
}
