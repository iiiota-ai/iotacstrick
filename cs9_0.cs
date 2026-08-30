// C# 9.0

// 1. and or not
int a = 3;
if(a is 2 or 3 or 5 or 7 or 11)     // 2已经变成一个pattern了
{
    "a is a prime number".Dump();
}

if(a is > 2 and <5)
{
    "a gt 2 and lt 5".Dump();
}

var pair = (3, 5);
if(pair is (>2, not 4))
{
    "pass".Dump();
}

// 2. Static lambda expressions

Foo();

void Foo()
{
    var x = 10;

    // 以前的写法，内部函数可以访问局部变量
    void InnerFunc()
    {
        x.Dump();
    }

    // static修饰，禁止访问外部变量（可以传参方式获取）
    static void InnerFunc1()
    {
        "static Func".Dump();
    }

    InnerFunc();
}

var list = Enumerable.Range(1, 10).ToList();
var divisor = 2;
list.Where(x => x % divisor == 0).ToList().Dump();  // 匿名Lambda可以访问局部变量
list.Where(static x => x % 2 == 0).ToList().Dump();        // 匿名static Lambda表达式不可访问局部变量