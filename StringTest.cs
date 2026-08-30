// String中反直觉用法

// 字符串中查找子串用：Contains
var str = "Hello world";
var s = "wor";

var find1 = str.Contains(s);
var find2 = str.IndexOf(s) < 0;
var find3 = Regex.IsMatch(str, s);

// ！！！Benchmark基准测试中，Contains最快，IndexOf最慢，平均相差100x，Regex.IsMatch平均相差10x