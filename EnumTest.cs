// 枚举是可以定义数据类型的
// 首个枚举的值可自定义，后续一次递增

Enum.GetValues<Colors>().Select(c => (c, c.GetTypeCode(), (int)c)).Dump();

enum Colors : byte
{
    Red = 0x10,
    Green,
    Blue
}