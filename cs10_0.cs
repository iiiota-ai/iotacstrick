// C#10.0

// 1. inferred delegate type，编译器自动推断委托类型，这里是Action<int>
var func = (int a) => { "Hello World".Dump(); };
// 老版本必须显式声明类型
Action<int> func_old = (int a) => { "Hello World".Dump(); };

// 2. global using
//global using System.Linq;
// 整个程序集中的每个cs文件都会引入这个命名空间