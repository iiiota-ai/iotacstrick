// C#3.0 Anonymous Types

// 类型：AnonymousType<string, int>
var obj = new { Name = "Tom", Age = 18 };
obj.Dump();

var obj1 = new { };

// Benchmark基准测试中，new { } 和 new object() 性能是一样的
//BenchmarkRunner.Run<ObjectCreator>(); 

//public class ObjectCreator
//{
//    [Benchmark]
//    public object NewAnonymousType()
//    {
//        return new { };
//    }

//    public object NewOject()
//    {
//        return new object();
//    }
//}
