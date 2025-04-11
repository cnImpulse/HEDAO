using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EnemyRole : Role
{
    protected override void OnInit(object data)
    {
        base.OnInit(data);

        var cfgId = (int)data;
        var cfg = GameMgr.Cfg.TbRole.Get(cfgId);
        Name = cfg.Name;
        Level = cfg.Level;
        
        Attr.Init(cfg.BaseAttr);

        foreach(var id in cfg.SkillSet)
        {
            SkillSet.Add(id);
        }
        MoveSkillSet.Add(cfg.MoveSkillId);
    }
}