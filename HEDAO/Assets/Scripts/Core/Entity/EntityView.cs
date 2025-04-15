using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    public long Id => Entity.Id;

    public Entity Entity;

    public void Init(Entity entity, object data = default)
    {
        Entity = entity;

        OnInit(data);
    }

    public void Destroy()
    {
        OnDestroy();
    }

    protected virtual void OnInit(object data)
    {

    }

    protected virtual void OnDestroy()
    {

    }

    public void Hide()
    {
        GameMgr.Entity.HideEntity(Entity.Id);
    }
}
