using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : BaseManager
{
    private long m_CurMaxId = 0;
    private readonly Dictionary<long, EntityView> m_EntityViewDict = new Dictionary<long, EntityView>();

    public void ShowEntity<T>(Entity entity, object data = default)
        where T : EntityView
    {
        var path = GameMgr.Cfg.TbRes.Get(entity.GetPrefabId()).Path;
        var go = GameMgr.Res.LoadAsset<GameObject>(path);
        
        var view = go.AddComponent<T>();
        m_EntityViewDict.Add(entity.Id, view);

        view.Init(entity, data);
    }

    public void HideEntity(long id)
    {
        m_EntityViewDict.Remove(id);
    }

    public T GetEntityView<T>(long id)
        where T : EntityView
    {
        return m_EntityViewDict[id] as T;
    }

    public long GetNextId()
    {
        m_CurMaxId++;
        return m_CurMaxId;
    }
}
