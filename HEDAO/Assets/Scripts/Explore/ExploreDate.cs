using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreDate
{
    public Queue<List<ExploreNode>> ExploreQueue = new Queue<List<ExploreNode>>();
    public Dictionary<long, PlayerRole> Team => GameMgr.Save.Data.TeamDict;

    public ExploreDate()
    {
    }

    public void Init()
    {
        for (int i = 0; i < 6; ++i)
        {
            List<ExploreNode> nodes = new List<ExploreNode>();
            foreach (var cfg in GameMgr.Cfg.TbExploreNodeCfg.DataList.GetRandom(3))
            {
                if (cfg.ExploreType == Cfg.EExploreType.Battle)
                {
                    nodes.Add(new BattleNode(cfg.Id));
                }
                else if (cfg.ExploreType == Cfg.EExploreType.Effect)
                {
                    nodes.Add(new EffectNode(cfg.Id));
                }
            }
            ExploreQueue.Enqueue(nodes);
        }
    }
}
