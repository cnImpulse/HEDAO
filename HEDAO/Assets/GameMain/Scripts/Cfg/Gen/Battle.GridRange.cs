
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.Battle
{
public sealed partial class GridRange : Luban.BeanBase
{
    public GridRange(ByteBuf _buf) 
    {
        Type = (EGridRangeType)_buf.ReadInt();
        Distance = _buf.ReadInt();
    }

    public static GridRange DeserializeGridRange(ByteBuf _buf)
    {
        return new Battle.GridRange(_buf);
    }

    public readonly EGridRangeType Type;
    public readonly int Distance;
   
    public const int __ID__ = 1157651425;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "Type:" + Type + ","
        + "Distance:" + Distance + ","
        + "}";
    }
}

}
