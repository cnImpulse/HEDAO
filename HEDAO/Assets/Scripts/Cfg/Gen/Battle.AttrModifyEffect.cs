
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
public sealed partial class AttrModifyEffect : EffectCfg
{
    public AttrModifyEffect(ByteBuf _buf)  : base(_buf) 
    {
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);AttrDict = new System.Collections.Generic.Dictionary<EAttrType, int>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { EAttrType _k0;  _k0 = (EAttrType)_buf.ReadInt(); int _v0;  _v0 = _buf.ReadInt();     AttrDict.Add(_k0, _v0);}}
    }

    public static AttrModifyEffect DeserializeAttrModifyEffect(ByteBuf _buf)
    {
        return new Battle.AttrModifyEffect(_buf);
    }

    public readonly System.Collections.Generic.Dictionary<EAttrType, int> AttrDict;
   
    public const int __ID__ = 483143154;
    public override int GetTypeId() => __ID__;

    public override void ResolveRef(Tables tables)
    {
        base.ResolveRef(tables);
        
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "AttrDict:" + Luban.StringUtil.CollectionToString(AttrDict) + ","
        + "}";
    }
}

}
