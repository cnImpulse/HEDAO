using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    public Entity Entity;

    public void Init(Entity entity, object data = default)
    {
        Entity = entity;

        OnInit(data);
    }

    protected virtual void OnInit(object data)
    {

    }
}
