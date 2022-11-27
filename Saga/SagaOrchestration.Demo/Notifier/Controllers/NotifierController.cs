using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifierController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] Models.Notifier notifier)
        {
            Console.WriteLine($"Sent notification for: {notifier.ProductName}");
            return 3;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Console.WriteLine($"Sent rollback transaction notification: {id}");
        }
    }
}
