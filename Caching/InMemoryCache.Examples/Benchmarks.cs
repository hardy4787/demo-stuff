using BenchmarkDotNet.Attributes;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Examples
{
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        private readonly IAppCache _appCache = new CachingService();
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        [Benchmark]
        public int GetOrCreate_MemoryCache()
        {
            return _memoryCache.GetOrCreate("set", _ => 69);
        }

        [Benchmark]
        public int GetOrAdd_LazyCache()
        {
            return _appCache.GetOrAdd("add", _ => 69);
        }
    }
}
