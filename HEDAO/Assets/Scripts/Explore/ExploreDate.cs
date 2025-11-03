using System.Collections;
using System.Collections.Generic;
using Map;

public class ExploreDate
{
    public Map.Map Map;
    public Queue<List<ExploreNode>> ExploreQueue = new Queue<List<ExploreNode>>();
    public Dictionary<long, PlayerRole> Team => GameMgr.Save.Data.TeamDict;

    public ExploreDate()
    {
    }

    public void Init()
    {
        var mapCfg = GameMgr.Res.LoadAsset<MapConfig>("Assets/Res/Scriptable Objects/MapConfigs/DefaultMapConfig.asset");
        Map = MapGenerator.GetMap(mapCfg);
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
