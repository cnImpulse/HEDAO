
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
public sealed partial class LevelCfg : Luban.BeanBase
{
    public LevelCfg(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        MaxQi = _buf.ReadInt();
        Exp = _buf.ReadInt();
    }

    public static LevelCfg DeserializeLevelCfg(ByteBuf _buf)
    {
        return new LevelCfg(_buf);
    }

    /// <summary>
    /// 编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 名字
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 最大灵气
    /// </summary>
    public readonly int MaxQi;
    /// <summary>
    /// 突破瓶颈值
    /// </summary>
    public readonly int Exp;
   
    public const int __ID__ = -2067008928;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "MaxQi:" + MaxQi + ","
        + "Exp:" + Exp + ","
        + "}";
    }
}

}
