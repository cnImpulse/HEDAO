
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
public sealed partial class WorldUnitCfg : Luban.BeanBase
{
    public WorldUnitCfg(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
    }

    public static WorldUnitCfg DeserializeWorldUnitCfg(ByteBuf _buf)
    {
        return new WorldUnitCfg(_buf);
    }

    /// <summary>
    /// 编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 名字
    /// </summary>
    public readonly string Name;
   
    public const int __ID__ = 1748342894;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "}";
    }
}

}