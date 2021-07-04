``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Big Sur 11.4 (20F71) [Darwin 20.5.0]
Apple M1 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=5.0.301
  [Host]   : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT  [AttachedDebugger]
  .NET 5.0 : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  InvocationCount=1  
UnrollFactor=1  

```
|           Method | ListSizes |         Mean |      Error |      StdDev |
|----------------- |---------- |-------------:|-----------:|------------:|
|      **IfCondition** |      **1000** |     **4.850 μs** |  **0.0982 μs** |   **0.1206 μs** |
| TernaryCondition |      1000 |     4.889 μs |  0.1021 μs |   0.0955 μs |
|      **IfCondition** |     **10000** |    **47.054 μs** |  **0.8672 μs** |   **0.8111 μs** |
| TernaryCondition |     10000 |    46.812 μs |  0.7336 μs |   0.5728 μs |
|      **IfCondition** |    **100000** |   **479.152 μs** |  **0.6400 μs** |   **0.4997 μs** |
| TernaryCondition |    100000 |   444.997 μs |  2.2702 μs |   1.7724 μs |
|      **IfCondition** |   **1000000** | **4,319.640 μs** | **84.7061 μs** | **113.0802 μs** |
| TernaryCondition |   1000000 | 4,324.334 μs | 86.1745 μs | 136.6820 μs |
