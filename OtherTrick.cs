//1. 全局命名空间  global::

using System;

public class MyClass
{
    public void WriteLine()
    {
        //Console.Wr        // 报错
        //System.Cons       // 报错
        global::System.Console.WriteLine();     // 极端条件下，常见于第三方框架，如protobuf
    }

    private const int Console = 1;

    public class System
    {

    }
}