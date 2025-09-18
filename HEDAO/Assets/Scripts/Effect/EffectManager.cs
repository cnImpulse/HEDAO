using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EffectManager : BaseManager
{
    public long ShowEffect(EffectData data, bool isSingleton = false)
    {
        if (isSingleton)
        {
            HideEffectByPrefabId(data.PrefabId);
        }

        GameMgr.Entity.ShowEntity<EffectView>(data);
        return data.Id;
    }

    public long ShowEffect(int prefabId, long followId)
    {
        return ShowEffect(new EffectData() { PrefabId = prefabId, FollowId = followId });
    }

    public void HideEffect(long effectId)
    {
        GameMgr.Entity.HideEntity(effectId);
    }
    
    public void HideEffectByPrefabId(int prefabId)
    {
        List<long> list = new List<long>();
        foreach(var view in GameMgr.Entity.EntityViewDict.Values)
        {
            var effect = view as EffectView;
            if (effect != null && effect.Data.PrefabId == prefabId)
            {
                list.Add(effect.Id);
            }
        }

        foreach(var id in list)
        {
            HideEffect(id);
        }
    }

    public long ShowFxSelect(long entityId)
    {
        var effectId = GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10006, FollowId = entityId });
        var view = GameMgr.Entity.GetEntityView<BattleUnitView>(entityId);
        view?.PlayAnim("selected");
        return effectId;
    }
}
