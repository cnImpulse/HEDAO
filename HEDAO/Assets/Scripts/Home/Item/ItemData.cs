using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;

public class ItemData
{
    public int CfgId { get; private set; }
    public ItemCfg Cfg => GameMgr.Cfg.TbItem.Get(CfgId);

    public ItemData(int cfgId)
    {
        CfgId = cfgId;
    } 
}
