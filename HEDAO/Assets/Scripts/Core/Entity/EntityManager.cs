using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : BaseManager
{
    private long m_CurMaxId = 0;
    public readonly Dictionary<long, EntityView> EntityViewDict = new Dictionary<long, EntityView>();

    public T ShowEntity<T>(Entity entity, object data = default)
        where T : EntityView
    {
        var path = GameMgr.Cfg.TbRes.Get(entity.GetPrefabId()).Path;
        var go = GameMgr.Res.LoadAsset<GameObject>(path);
        
        var view = go.AddComponent<T>();
        EntityViewDict.Add(entity.Id, view);

        view.Init(entity, data);

        return view;
    }

    public void HideEntity(long id)
    {
        if (EntityViewDict.TryGetValue(id, out EntityView view))
        {
            view.Destroy();
            GameObject.Destroy(view.gameObject);
            EntityViewDict.Remove(id);
        }
    }

    public T GetEntityView<T>(long id)
        where T : EntityView
    {
        if (EntityViewDict.TryGetValue(id, out EntityView view))
        {
            return view as T;
        }

        return default;
    }

    public long GetNextId()
    {
        m_CurMaxId++;
        return m_CurMaxId;
    }
}
