using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExploreNode
{
    public int CfgId { get; private set; }
    public Cfg.ExploreNodeCfg Cfg => GameMgr.Cfg.TbExploreNodeCfg.Get(CfgId);

    public ExploreNode(int id)
    {
        CfgId = id;
    }

    public virtual void OnSelected()
    {

    }
}
