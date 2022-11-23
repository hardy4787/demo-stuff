using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CachingExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PocController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public PocController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public IActionResult Set(string value, string key)
        {
            _memoryCache.Set(key, value, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(40),
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
            if(!_memoryCache.TryGetValue(key, out string value))
            {
                return NotFound();
            }

            return Ok(value);
        }
    }
}