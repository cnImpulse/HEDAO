
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg
{
public sealed partial class Range : Luban.BeanBase
{
    public Range(ByteBuf _buf) 
    {
        Min = _buf.ReadInt();
        Max = _buf.ReadInt();
    }

    public static Range DeserializeRange(ByteBuf _buf)
    {
        return new Range(_buf);
    }

    public readonly int Min;
    public readonly int Max;
   
    public const int __ID__ = 78727453;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "Min:" + Min + ","
        + "Max:" + Max + ","
        + "}";
    }
}

}
