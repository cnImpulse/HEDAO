//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;



namespace Cfg.Battle
{

public sealed partial class BattleSkillCfg :  Bright.Config.BeanBase 
{
    public BattleSkillCfg(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Desc = _buf.ReadString();
        Icon = _buf.ReadString();
        Cost = _buf.ReadInt();
        Power = _buf.ReadInt();
        CastDistance = _buf.ReadInt();
        EffectDistance = _buf.ReadInt();
        PostInit();
    }

    public static BattleSkillCfg DeserializeBattleSkillCfg(ByteBuf _buf)
    {
        return new Battle.BattleSkillCfg(_buf);
    }

    /// <summary>
    /// 编号
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 简介
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; private set; }
    /// <summary>
    /// 释放消耗灵气
    /// </summary>
    public int Cost { get; private set; }
    /// <summary>
    /// 威力
    /// </summary>
    public int Power { get; private set; }
    /// <summary>
    /// 释放距离
    /// </summary>
    public int CastDistance { get; private set; }
    /// <summary>
    /// 作用距离
    /// </summary>
    public int EffectDistance { get; private set; }

    public const int __ID__ = 321890593;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "Desc:" + Desc + ","
        + "Icon:" + Icon + ","
        + "Cost:" + Cost + ","
        + "Power:" + Power + ","
        + "CastDistance:" + CastDistance + ","
        + "EffectDistance:" + EffectDistance + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}
