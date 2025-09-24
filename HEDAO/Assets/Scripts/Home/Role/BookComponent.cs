using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class BookComponent : Component
{
    public new Role Owner => base.Owner as Role;
    public Dictionary<EBookType, int> BookDict = new Dictionary<EBookType, int>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        foreach (var bookId in Owner.InitCfg.BookList)
        {
            LearnBook(bookId);
        }
    }

    public int GetBook(EBookType type)
    {
        if (BookDict.TryGetValue(type, out int cfgId))
        {
            return cfgId;
        }

        return 0;
    }

    public bool CanLearnBook(int cfgId)
    {
        // var cfg = GameMgr.Cfg.TbBook.Get(cfgId);
        // if (cfg.BookType == EBookType.ShuFa || cfg.BookType == EBookType.DunFa)
        // {
        //     // 先学道法
        //     if (!BookDict.ContainsKey(EBookType.DaoFa)) return false;
        //
        //     // 五行契合
        //     //if (cfg.WuXinType != EWuXinType.None && cfg.WuXinType != QiWuXinType)
        //     //{
        //     //    return false;
        //     //}
        // }

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
                Owner.Buff.AddBuff(buffId, default);
            }

            foreach (var skillId in cfg.SkillList)
            {
                Owner.AddSkill(skillId);
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
                Owner.Buff.RemoveBuff(buffId);
            }

            foreach (var skillId in cfg.SkillList)
            {
                Owner.RemoveSkill(skillId);
            }
        }
    }
}
