// C# 7.0 Binary Literals and Digit Separators

// 1. _分隔提高可读性，不影响编译
long bigNum1 = 1_000_000_000;
long bigNum2 = 1_000_00_00_0;
long bigNum3 = 0b1_000_000_0;   // 二进制同理

// 2. throw
int? input = null;
// 老写法
if (input == null)
    throw new ArgumentException();
// 新写法
var res = input ?? throw new ArgumentException();
