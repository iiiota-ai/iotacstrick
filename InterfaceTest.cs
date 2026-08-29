using System.Collections.ObjectModel;

var myClass = new MyClass();

// 报错，显式实现的接口方法必须显式调用，否则提示不存在这个方法
//myClass.Foo();
((IFoo)myClass).Foo();


//这种用法作用的是什么？实际案例:
var dic = new Dictionary<string, string>();
dic["1"] = "one";

var readonlyDic = new ReadOnlyDictionary<string, string>(dic);

readonlyDic["1"].Dump();
//报错（不可修改），内部就是通过显式实现接口的方式。
//readonlyDic["2"] = "two";

//使用显式调用接口方法(有些IDE直接会提示报错)，可以但运行时报错
((IDictionary<string, string>)readonlyDic).Add("2", "two");


interface IFoo
{
    void Foo();
}

class MyClass : IFoo
{
    // 显式实现接口方法
    void IFoo.Foo()
    {
        "Foo method".Dump();
    }
}

