
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
public sealed partial class RoleTempCfg : Luban.BeanBase
{
    public RoleTempCfg(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        WuXinRange = Range.DeserializeRange(_buf);
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);InitAttr = new System.Collections.Generic.Dictionary<EAttrType, int>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { EAttrType _k0;  _k0 = (EAttrType)_buf.ReadInt(); int _v0;  _v0 = _buf.ReadInt();     InitAttr.Add(_k0, _v0);}}
    }

    public static RoleTempCfg DeserializeRoleTempCfg(ByteBuf _buf)
    {
        return new RoleTempCfg(_buf);
    }

    /// <summary>
    /// 编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 五行天赋区间
    /// </summary>
    public readonly Range WuXinRange;
    public readonly System.Collections.Generic.Dictionary<EAttrType, int> InitAttr;
   
    public const int __ID__ = 870822522;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        WuXinRange?.ResolveRef(tables);
        
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "WuXinRange:" + WuXinRange + ","
        + "InitAttr:" + Luban.StringUtil.CollectionToString(InitAttr) + ","
        + "}";
    }
}

}
