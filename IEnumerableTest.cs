using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

MyClass myClass = new MyClass();

// foreach本质上调用GetEnumerator获取枚举器进行迭代
foreach (var item in myClass)
{
    item.Dump();
}

// foreach本质上调用GetAsyncEnumerator获取异步枚举器进行迭代
await foreach (var item in myClass)
{
    item.Dump();
}

// 本质上调用GetAwaiter返回TaskAwaiter，就都能await
await myClass;
"结束".Dump();

// 使用基本类型的扩展枚举器
foreach(var item in 3)
{
    item.Dump();
}

// 枚举器
public class MyClass
     //: IEnumerable, IAsyncEnumerable<int>
{
    //public IEnumerator GetEnumerator()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        yield return i;
    //    }
    //}

    //public async IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancell)
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        await Task.Delay(500);
    //        yield return i;
    //    }
    //}

    //public TaskAwaiter GetAwaiter()
    //{
    //    return Task.Delay(TimeSpan.FromSeconds(5f)).GetAwaiter();
    //}
}

// 甚至可以作为扩展方法，但Class不可显式实现IEnumerable, IAsyncEnumerable<int>（报错），编译器会自动优化补全

public static class MyExtenstions
{
    public static IEnumerator GetEnumerator(this MyClass myClass)
    {
        for(int i = 0; i < 5; i++)
        {
            yield return i;
        }
    }

    public static async IAsyncEnumerator<int> GetAsyncEnumerator(this MyClass myClass)
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(500);
            yield return i;
        }
    }

    public static TaskAwaiter GetAwaiter(this MyClass myClass)
    {
        return Task.Delay(TimeSpan.FromSeconds(5f)).GetAwaiter();
    }


    // 甚至可以给基本类型写枚举器
    public static IEnumerator GetEnumerator(this int count)
    {
        for(int i = 0; i < count; i++)
        {
            yield return i;
        }
    }
}
