
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.Common
{
public partial class TbMisc
{

     private readonly MiscCfg _data;

     public MiscCfg Data => _data;

    public TbMisc(ByteBuf _buf)
    {
        int n = _buf.ReadSize();
        if (n != 1) throw new SerializationException("table mode=one, but size != 1");
        _data = MiscCfg.DeserializeMiscCfg(_buf);
    }


    /// <summary>
    /// 功法类型列表
    /// </summary>
     public System.Collections.Generic.List<EBookType> BookTypeList => _data.BookTypeList;
    /// <summary>
    /// 属性类型列表
    /// </summary>
     public System.Collections.Generic.List<EAttrType> AttrTypeList => _data.AttrTypeList;
     public int MinHit => _data.MinHit;
     public System.Collections.Generic.List<int> InitRoleList => _data.InitRoleList;
    
    public void ResolveRef(Tables tables)
    {
        _data.ResolveRef(tables);
    }
}

}

