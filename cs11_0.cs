//1. 数值类型 INumber<T>

using System.Numerics;

var myClass = new MyClass();
myClass.Foo(10);
myClass.Foo(9.9f);
//myClass.Foo(string.Empty); // 报错

myClass.Max(100, 1000);


public class MyClass
{
    public void Foo<T>(T value) where T : INumber<T>
    {
        value.Dump();
    }

    public void Max<T>(T v1, T v2) where T : INumber<T>
    {
        var max = T.Max(v1, v2);
        max.Dump();
    }
}