// c# 8.0

// 1. Indices and Ranges
var arr = new[] { 1, 2, 3, 4 };

// 倒数第一个，以前写法
arr[arr.Length - 1].Dump();
// 新写法
arr[^1].Dump();
// 新写法，范围
arr[1..4].Dump();

// 甚至可以是表达式
var i = ^1;
i.Dump();
arr[i].Dump();


// 自己可以扩展迭代写法
foreach(var index in 10..15)
{
   index.Dump();
}

// 2. Pattern matching enhancements

MyClass? c = null;
if(c != null)
{
    "c is not null".Dump();     // 逻辑会执行进来，因为重写了!=运算符
}

// is not 底层编译为：(object)c != null
if(c is not null)
{
    "c is not null".Dump();     // 逻辑不会执行进来
}

static class MyExtensions
{
    public static IEnumerator<int> GetEnumerator(this Range range)
    {
        if (range.End.IsFromEnd || range.Start.IsFromEnd)
            throw new ArgumentException(nameof(range));
        for (int i = range.Start.Value; i < range.End.Value; i++)
        {
            yield return i;
        }
    }
}

class MyClass
{
    public int value { get; set; }
    // 重写运算符

    public static bool operator ==(MyClass c1, MyClass c2)
    {
        return true;
    }

    public static bool operator !=(MyClass c1, MyClass c2)
    {
        return true;
    }
}

// 2. null-coalescing ?? ??= 空合并

//int GetValue()
//{
//    int? x = null;
//    // ??：表示为null返回其后的默认值
//    return x ?? -1;
//}