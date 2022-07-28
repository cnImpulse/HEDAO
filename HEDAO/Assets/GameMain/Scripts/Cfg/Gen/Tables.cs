//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;


namespace Cfg
{
   
public partial class Tables
{
    public Battle.TbRoleCfg TbRoleCfg {get; }
    public Effect.TbEffect TbEffect {get; }
    public Effect.TbGridEffect TbGridEffect {get; }
    public Battle.TbBattleSkillCfg TbBattleSkillCfg {get; }
    public Battle.TbMoveSkillCfg TbMoveSkillCfg {get; }

    public Tables(System.Func<string, ByteBuf> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        TbRoleCfg = new Battle.TbRoleCfg(loader("battle_tbrolecfg")); 
        tables.Add("Battle.TbRoleCfg", TbRoleCfg);
        TbEffect = new Effect.TbEffect(loader("effect_tbeffect")); 
        tables.Add("Effect.TbEffect", TbEffect);
        TbGridEffect = new Effect.TbGridEffect(loader("effect_tbgrideffect")); 
        tables.Add("Effect.TbGridEffect", TbGridEffect);
        TbBattleSkillCfg = new Battle.TbBattleSkillCfg(loader("battle_tbbattleskillcfg")); 
        tables.Add("Battle.TbBattleSkillCfg", TbBattleSkillCfg);
        TbMoveSkillCfg = new Battle.TbMoveSkillCfg(loader("battle_tbmoveskillcfg")); 
        tables.Add("Battle.TbMoveSkillCfg", TbMoveSkillCfg);

        PostInit();
        TbRoleCfg.Resolve(tables); 
        TbEffect.Resolve(tables); 
        TbGridEffect.Resolve(tables); 
        TbBattleSkillCfg.Resolve(tables); 
        TbMoveSkillCfg.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        TbRoleCfg.TranslateText(translator); 
        TbEffect.TranslateText(translator); 
        TbGridEffect.TranslateText(translator); 
        TbBattleSkillCfg.TranslateText(translator); 
        TbMoveSkillCfg.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}