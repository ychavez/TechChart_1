using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Linq.Expressions;

var summary = BenchmarkRunner.Run<BenchmarkTests>();
[MemoryDiagnoser(false)]
public class BenchmarkTests
{
    private const int Iterations = 1000;
    private List<int> listData;
    private IEnumerable<int> enumerableData;


    [GlobalSetup]
    public void Setup()
    {
        listData = Enumerable.Range(0, Iterations).ToList();
        enumerableData = Enumerable.Range(0, Iterations);
    }


    [Benchmark]
    public void ListWhere()
    {
        var filtered = listData.Where(x => x % 2 == 0).ToList();
        foreach (var item in filtered)
        {
            
        }
    }

    [Benchmark]
    public void EnumerableWhereList()
    {
        var filtered = enumerableData.Where(x => x % 2 == 0).ToList();
        foreach (var item in filtered)
        {

        }
    }

    [Benchmark]
    public void EnumerableWhere()
    {
        var filtered = enumerableData.Where(x => x % 2 == 0);
        foreach (var item in filtered)
        {

        }
    }



    [Benchmark]
    public void EnumerableWhereListWhere()
    {
        var filtered = enumerableData.ToList().Where(x => x % 2 == 0).ToList();
        foreach (var item in filtered)
        {

        }
    }






}