using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class PlayerRole : Role
{
    protected override void OnInit(object data)
    {
        base.OnInit(data);

        var cfg = GameMgr.Cfg.TbRoleTempCfg.Get(1);
        Name = data as string;
        Level = 1;
        Attr.Init(cfg.InitAttr);
        for (int i = 1; i < 6; i++)
        {
            WuXin.Add((EWuXinType)i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
        }

        MoveSkillSet.Add(1001);
        
        var tagList = GameMgr.Cfg.TbRoleTagCfg.DataList;
        AddTag(tagList[Random.Range(0, tagList.Count)].Id);
    }

    public bool CanLearnBook(int cfgId)
    {
        var cfg = GameMgr.Cfg.TbBook.Get(cfgId);
        if (cfg.BookType == EBookType.ShuFa || cfg.BookType == EBookType.DunFa)
        {
            // 先学道法
            if (!BookDict.ContainsKey(EBookType.DaoFa)) return false; 

            // 五行契合
            if (cfg.WuXinType != EWuXinType.None && cfg.WuXinType != QiWuXinType)
            {
                return false;
            }
        }

        return true;
    }

    public void LearnBook(int cfgId)
    {
        if (!CanLearnBook(cfgId)) return;

        var cfg = GameMgr.Cfg.TbBook.Get(cfgId);
        if (BookDict.TryAdd(cfg.BookType, cfgId))
        {
            foreach (var buffId in cfg.BuffList)
            {
                AddBuff(buffId);
            }

            foreach (var skillId in cfg.SkillList)
            {
                AddSkill(skillId);
            }
        }
    }

    public void ForgetBook(int cfgId)
    {
        var cfg = GameMgr.Cfg.TbBook.Get(cfgId);
        if (BookDict.ContainsKey(cfg.BookType))
        {
            BookDict.Remove(cfg.BookType);
            foreach (var buffId in cfg.BuffList)
            {
                RemoveBuff(buffId);
            }

            foreach (var skillId in cfg.SkillList)
            {
                RemoveSkill(skillId);
            }
        }
    }
}