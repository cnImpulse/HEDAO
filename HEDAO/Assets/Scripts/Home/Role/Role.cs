using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;
using UnityEngine.EventSystems;

public class Role : Entity
{
    public string Name;
    public int Level { get; protected set; }
    public int InitCfgId { get; protected set; }
    public RoleCfg InitCfg => GameMgr.Cfg.TbRole.Get(InitCfgId);

    public RoleAttrComponent Attr => GetComponent<RoleAttrComponent>();
    public SkillComponent Skill => GetComponent<SkillComponent>();
    public BuffComponent Buff => GetComponent<BuffComponent>();
    public BookComponent Book => GetComponent<BookComponent>();
    public EquipComponent Equip => GetComponent<EquipComponent>();
    public BattleComponent Battle => GetComponent<BattleComponent>();

    public Dictionary<EWuXinType, int> WuXin = new Dictionary<EWuXinType, int>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        InitCfgId = (int)data;
        Name = InitCfg.Name;
        Level = InitCfg.Level;

        AddComponent<RoleAttrComponent>();
        AddComponent<SkillComponent>();
        AddComponent<BookComponent>();
        AddComponent<EquipComponent>();
        AddComponent<BattleComponent>();
        AddComponent<BuffComponent>();
    }

    public void LevelUp(int level)
    {

    }

    public bool CheckCondition(int id)
    {
        if (!GameMgr.Cfg.TbConditionCfg.DataMap.ContainsKey(id))
        {
            return true;
        }
        
        var cfg = GameMgr.Cfg.TbConditionCfg.Get(id);
        return Level >= cfg.Level;
    }

    public void AddSkill(int id)
    {
        Skill.AddSkill(id);
    }

    public void RemoveSkill(int id)
    {
        Skill.RemoveSkill(id);
    }

    public override int GetPrefabId()
    {
        return 10002;
    }
}