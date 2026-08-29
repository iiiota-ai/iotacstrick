using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

MyClass myClass = new MyClass();

"开始".Dump();
// 本质上调用GetAwaiter返回TaskAwaiter，就都能await
await myClass;
"结束".Dump();

// 枚举器
public class MyClass
{
    //public TaskAwaiter GetAwaiter()
    //{
    //    return Task.Delay(TimeSpan.FromSeconds(5f)).GetAwaiter();
    //}
}

public static class MyExtenstions
{
    public static TaskAwaiter GetAwaiter(this MyClass myClass)
    {
        return Task.Delay(TimeSpan.FromSeconds(5f)).GetAwaiter();
    }
}
