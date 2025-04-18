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

    public long ShowGridEffect(List<Vector2Int> gridList, Color color, float life = -1)
    {
        HideGridEffect();
        
        GridEffectData data = new GridEffectData();
        data.PrefabId = 10004;
        data.LifeTime = life;
        data.GridList = gridList;
        data.Color = color;
        GameMgr.Entity.ShowEntity<GridEffectView>(data);
        return data.Id;
    }

    public void HideEffect(long entityId)
    {
        GameMgr.Entity.HideEntity(entityId);
    }
    
    public void HideGridEffect()
    {
        HideEffectByPrefabId(10004);
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
