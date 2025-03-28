
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
public partial class Tables
{
    public Battle.TbCharacter TbCharacter {get; }
    public Effect.TbEffect TbEffect {get; }
    public Effect.TbGridEffect TbGridEffect {get; }
    public Battle.TbBuffCfg TbBuffCfg {get; }
    public Battle.TbEffectCfg TbEffectCfg {get; }
    public Battle.TbConditionCfg TbConditionCfg {get; }
    public Building.TbBuildingCfg TbBuildingCfg {get; }
    public XiuLian.TbXiuLianCfg TbXiuLianCfg {get; }
    public XiuLian.TbLevelCfg TbLevelCfg {get; }
    public ZongMen.TbRoleTempCfg TbRoleTempCfg {get; }
    public Entity.TbEntityCfg TbEntityCfg {get; }
    public World.TbWorldUnitCfg TbWorldUnitCfg {get; }
    public World.TbActionCfg TbActionCfg {get; }

    public Tables(System.Func<string, ByteBuf> loader)
    {
        TbCharacter = new Battle.TbCharacter(loader("battle_tbcharacter"));
        TbEffect = new Effect.TbEffect(loader("effect_tbeffect"));
        TbGridEffect = new Effect.TbGridEffect(loader("effect_tbgrideffect"));
        TbBuffCfg = new Battle.TbBuffCfg(loader("battle_tbbuffcfg"));
        TbEffectCfg = new Battle.TbEffectCfg(loader("battle_tbeffectcfg"));
        TbConditionCfg = new Battle.TbConditionCfg(loader("battle_tbconditioncfg"));
        TbBuildingCfg = new Building.TbBuildingCfg(loader("building_tbbuildingcfg"));
        TbXiuLianCfg = new XiuLian.TbXiuLianCfg(loader("xiulian_tbxiuliancfg"));
        TbLevelCfg = new XiuLian.TbLevelCfg(loader("xiulian_tblevelcfg"));
        TbRoleTempCfg = new ZongMen.TbRoleTempCfg(loader("zongmen_tbroletempcfg"));
        TbEntityCfg = new Entity.TbEntityCfg(loader("entity_tbentitycfg"));
        TbWorldUnitCfg = new World.TbWorldUnitCfg(loader("world_tbworldunitcfg"));
        TbActionCfg = new World.TbActionCfg(loader("world_tbactioncfg"));
        ResolveRef();
    }
    
    private void ResolveRef()
    {
        TbCharacter.ResolveRef(this);
        TbEffect.ResolveRef(this);
        TbGridEffect.ResolveRef(this);
        TbBuffCfg.ResolveRef(this);
        TbEffectCfg.ResolveRef(this);
        TbConditionCfg.ResolveRef(this);
        TbBuildingCfg.ResolveRef(this);
        TbXiuLianCfg.ResolveRef(this);
        TbLevelCfg.ResolveRef(this);
        TbRoleTempCfg.ResolveRef(this);
        TbEntityCfg.ResolveRef(this);
        TbWorldUnitCfg.ResolveRef(this);
        TbActionCfg.ResolveRef(this);
    }
}

}
