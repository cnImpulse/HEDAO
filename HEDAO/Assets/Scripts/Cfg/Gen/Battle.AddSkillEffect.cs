
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
public sealed partial class AddSkillEffect : EffectCfg
{
    public AddSkillEffect(ByteBuf _buf)  : base(_buf) 
    {
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);SkillList = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); SkillList.Add(_e0);}}
    }

    public static AddSkillEffect DeserializeAddSkillEffect(ByteBuf _buf)
    {
        return new Battle.AddSkillEffect(_buf);
    }

    public readonly System.Collections.Generic.List<int> SkillList;
   
    public const int __ID__ = -919847977;
    public override int GetTypeId() => __ID__;

    public override void ResolveRef(Tables tables)
    {
        base.ResolveRef(tables);
        
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "SkillList:" + Luban.StringUtil.CollectionToString(SkillList) + ","
        + "}";
    }
}

}
