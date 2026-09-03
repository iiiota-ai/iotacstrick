// 1. delegate委托

// 委托本质上是引用类型
var foo = new Foo(MyFunc);
// 委托可多次注册同一函数，调用时也会执行多次
foo += MyFunc;
// 委托调用时，会按照注册顺序执行
foo += MyFunc2;
foo.Invoke();
// 底层会维护一个调用列表（多播委托）
foo.GetInvocationList().Dump();

// 对于有返回值的委托，每个注册函数都会执行，但返回最后一个注册函数的结果
var foo2 = new Foo2(Foo2);
foo2 += Foo2_2;
var result = foo2.Invoke(1);
result.Dump();

void MyFunc()
{
    "Hello".Dump();
}

void MyFunc2()
{
    "World".Dump();
}

string Foo2(int num)
{
    num = num + 1;
    num.Dump();
    return num.ToString();
}

string Foo2_2(int num)
{
    num = num + 11;
    num.Dump();
    return num.ToString();
}

delegate void Foo();
delegate string Foo2(int num);

// 2. Action：Dotnet内置的一些强烈类型委托，最多支持16个参数
// 3. Func：同理，具有返回值的委托

// 4. event，为了解决生成委托实例必须传入一个方法，然而event并不需要
// 本质上是一种语法糖：内部自动生成一个私有Action，并提供Add/Remove方法，并且保证线程安全
// 5. 标准dotnet事件模式
//event Action valueChanged;
//delegate void EvetnHandler(object sender, EventArgs e)

// 6. 多播委托存在几点问题: 1. 调用时，若其中一个委托方法报错，后续方法都不会再执行 2.只有最后一个委托方法作为返回值 3.remove移除委托方法复杂度O(n) 4.线程不安全
