using BenchmarkDotNet.Attributes;

namespace KataAlgorithms.Benchmarks;

[MemoryDiagnoser(false)]
public class SearchBenchmarks
{
    [Params(100, 1000, 10000)] 
    public int _arraySize;

    private int[] _testArray;
    private int _testElement;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(1207);
        _testArray = Enumerable
            .Range(0, _arraySize)
            .Select(_ => random.Next())
            .ToArray();
        
        Array.Sort(_testArray);

        _testElement = _testArray[random.Next(0, _testArray.Length)];
    }

    [Benchmark]
    public int Array_LinearSearch_Custom() => _testArray.LinearSearch(_testElement);

    [Benchmark]
    public int Array_LinearSearch_ArrayApi() => Array.IndexOf(_testArray, _testElement);

    [Benchmark]
    public int Array_LinearSearch_Linq() => _testArray.First(el => el == _testElement);

    [Benchmark]
    public int Array_BinarySearch_Custom() => _testArray.BinarySearch(_testElement);

    [Benchmark]
    public int Array_BinarySearch_ArrayApi() => Array.BinarySearch(_testArray, _testElement);
}