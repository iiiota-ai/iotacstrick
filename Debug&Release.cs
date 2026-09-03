// Conditional特性只能用于void返回值的方法，对于局部方法必须是static的

#define ABC
using System.Diagnostics;

public class MyClass
{
    static void main()
    {
        var c = new MyClass();
        c.DebugMethod();        // 非Debug的编译不会有这行，即仅在DEBUG才生效
        c.Foo();                // 定义了ABC才会编译这行
        c.Bee();
    }

    [Conditional("ABC")]
    public void Foo()
    {

    }

    // 定义了DEBUG宏才生效，不进入RELEASE
    [Conditional("DEBUG")]
    public void DebugMethod()
    {

    }

    public void Bee()
    {
        Demo();

        [Conditional("DEBUG")]      // 对于局部方法必须是static的
        static void Demo()
        {

        }
    }
}