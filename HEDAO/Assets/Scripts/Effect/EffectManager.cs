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

    public void HideEffect(long entityId)
    {
        GameMgr.Entity.HideEntity(entityId);
    }
    
    public void HideEffectByPrefabId(int prefabId)
    {
        foreach(var view in GameMgr.Entity.EntityViewDict.Values)
        {
            var effect = view as EffectView;
            if (effect != null && effect.Data.PrefabId == prefabId)
            {
                view.Hide();
                break;
            }
        }
    }
}
