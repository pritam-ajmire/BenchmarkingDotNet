```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.4.1 (24E263) [Darwin 24.4.0]
Apple M2 Pro, 1 CPU, 12 logical and 12 physical cores
.NET SDK 8.0.115
  [Host]   : .NET 8.0.15 (8.0.1525.16413), Arm64 RyuJIT AdvSIMD
  .NET 8.0 : .NET 8.0.15 (8.0.1525.16413), Arm64 RyuJIT AdvSIMD

Job=.NET 8.0  Runtime=.NET 8.0  

```
| Method                     | Mean        | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Gen1   | Gen2   | Allocated | Alloc Ratio |
|--------------------------- |------------:|----------:|----------:|------:|--------:|-----:|-------:|-------:|-------:|----------:|------------:|
| ManualCloneSimple          |    55.82 ns |  0.156 ns |  0.138 ns |  0.02 |    0.00 |    1 | 0.0430 |      - |      - |     360 B |        0.07 |
| ManualCloneComplex         |   207.23 ns |  1.141 ns |  1.068 ns |  0.09 |    0.00 |    2 | 0.1166 |      - |      - |     976 B |        0.18 |
| SystemTextJsonCloneSimple  | 1,835.56 ns | 20.327 ns | 16.974 ns |  0.82 |    0.01 |    3 | 0.2441 | 0.0057 | 0.0038 |    2053 B |        0.39 |
| NewtonsoftJsonCloneSimple  | 2,233.91 ns | 16.194 ns | 14.355 ns |  1.00 |    0.01 |    4 | 0.6332 |      - |      - |    5312 B |        1.00 |
| SystemTextJsonCloneComplex | 3,748.76 ns | 20.689 ns | 17.277 ns |  1.68 |    0.01 |    5 | 0.5188 | 0.0153 | 0.0076 |    4342 B |        0.82 |
| NewtonsoftJsonCloneComplex | 5,073.40 ns | 23.867 ns | 22.325 ns |  2.27 |    0.02 |    6 | 1.1215 | 0.0076 |      - |    9392 B |        1.77 |
