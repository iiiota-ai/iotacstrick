using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

MyClass myClass = new MyClass();

foreach (var item in myClass)
{
    item.Dump();
}

await foreach (var item in myClass)
{
    item.Dump();
}

await myClass;
"结束".Dump();

// 枚举器
public class MyClass : IEnumerable, IAsyncEnumerable<int>
{
    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return i;
        }
    }

    public async IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancell)
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(500);
            yield return i;
        }
    }

    public TaskAwaiter GetAwaiter()
    {
        return Task.Delay(TimeSpan.FromSeconds(5f)).GetAwaiter();
    }
}

