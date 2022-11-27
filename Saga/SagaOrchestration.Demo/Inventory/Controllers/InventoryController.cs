using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] Models.Inventory inventory)
        {
            throw new Exception("Error creating order");
            Console.WriteLine($"Updated inventory for: {inventory.ProductName}");
            return 2;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Deleted inventory: {id}");
        }
    }
}
