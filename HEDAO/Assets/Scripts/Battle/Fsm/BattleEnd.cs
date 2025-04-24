using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        var e = new BattleEndEvent();
        e.Result = GameMgr.Battle.Data.BattleResult;
        e.ItemList = Reward.GenReward(10001);

        GameMgr.Event.Fire(GameEventType.BattleEvent, e);
    }

    public override void OnLeave()
    {


        base.OnLeave();
    }

    public static class Reward
    {
        public static List<ItemData> GenReward(int rewardId)
        {
            int totalWeight = 0;
            var cfg = GameMgr.Cfg.TbReward.GetOrDefault(rewardId);
            foreach (var itemId in cfg.ItemList)
            {
                var itemCfg = GameMgr.Cfg.TbItem.GetOrDefault(itemId);
                totalWeight += 1;
            }

            List<ItemData> itemList = new List<ItemData>();
            int num = Random.Range(1, cfg.ItemList.Count);

            for (int i = 0; i < num; ++i)
            {
                var random = Random.Range(1, totalWeight);
                foreach (var itemId in cfg.ItemList)
                {
                    var itemCfg = GameMgr.Cfg.TbItem.GetOrDefault(itemId);
                    var itemWeight = 1;
                    if (random <= itemWeight)
                    {
                        itemList.Add(ItemData.CreateItem(itemId));
                        break;
                    }
                    random -= itemWeight;
                }
            }

            return itemList;
        }
    }
}
