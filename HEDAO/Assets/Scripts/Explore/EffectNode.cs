using System.Collections;
using System.Collections.Generic;
using Cfg.Battle;
using UnityEngine;

public class EffectNode : ExploreNode
{
    public EffectNode(int id) : base(id)
    {
    }

    public override void OnSelected()
    {
        foreach(var role in Team.Values)
        {
            EffectCfg.TakeEffectList(Cfg.EffectList, null, role);
        }
    }
}
