using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EffectManager : BaseManager
{
    public long ShowEffect(int prefabId, Vector3 position = default, bool isSingleton = false, float lifetime = -1)
    {
        EffectData data = new EffectData(prefabId, position, lifetime);
        if (isSingleton)
        {
            HideEffect(prefabId);
        }

        GameMgr.Entity.ShowEntity<EffectView>(data);
        return data.Id;
    }

    public void HideEffect(int entityId)
    {

    }

    public void HideEffectByPrefabId(int prefabId)
    {

    }
}
