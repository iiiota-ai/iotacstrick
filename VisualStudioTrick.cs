// 1. 调试时，显示对象中的成员变量
// 可以通过重写ToString方法，但这样会影响业务逻辑（进入release包）

using System.Diagnostics;

// 在Debug时，对象仅提示指定的成员变量
[DebuggerDisplay("{Id}, {Name}")]
class Model
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]   // 在Debug时，不显示成员变量
    public int Id { get; set; }
    public string? Name { get; set; }

    public string Password { get; set; }

    [DebuggerHidden]                // Debug断点不进入此方法
    public string GetName()
    {
        return Name;
    }
}