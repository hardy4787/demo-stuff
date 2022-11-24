``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
AMD Ryzen 7 5825U with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


```
|                  Method |     Mean |    Error |   StdDev | Allocated |
|------------------------ |---------:|---------:|---------:|----------:|
| GetOrCreate_MemoryCache | 36.85 ns | 0.154 ns | 0.128 ns |         - |
|      GetOrAdd_LazyCache | 82.92 ns | 0.559 ns | 0.523 ns |      96 B |
