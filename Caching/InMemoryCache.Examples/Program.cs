using BenchmarkDotNet.Running;
using InMemoryCache.Examples;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;

//BenchmarkRunner.Run<Benchmarks>();
MemoryCacheApproach();
LazyCacheApproach();
void MemoryCacheApproach()
{
    var cache = new MemoryCache(new MemoryCacheOptions());
    var counter = 0;

    Parallel.ForEach(Enumerable.Range(1, 50), _ =>
    {
        var cachedItem = cache.GetOrCreate("key", _ => Interlocked.Increment(ref counter));
        Console.Write($"{cachedItem} ");
    });
}

void LazyCacheApproach()
{
    Console.WriteLine();
    IAppCache cache = new CachingService();
    var counter = 0;
    Parallel.ForEach(Enumerable.Range(1, 50), _ =>
    {
        var cachedItem = cache.GetOrAdd("key", _ => Interlocked.Increment(ref counter));
        Console.Write($"{cachedItem} ");
    });
}