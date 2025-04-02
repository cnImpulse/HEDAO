using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class PlayerRole : Role
{
    public PlayerRole()
    {
    }
    
    protected override void OnInit(object data)
    {
        base.OnInit(data);

        var cfg = GameMgr.Cfg.TbRoleTempCfg.Get(1);
        Name = data as string;
        Level = 1;
        Attr.Init(cfg.InitAttr);
        for (int i = 0; i < 5; i++)
        {
            WuXin.Add((EWuXinType)i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
        }

        var tagList = GameMgr.Cfg.TbRoleTagCfg.DataList;
        AddTag(tagList[Random.Range(0, tagList.Count)].Id);
    }
}