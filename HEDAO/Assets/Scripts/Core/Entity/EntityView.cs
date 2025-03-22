using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    public Entity Entity;

    public void Init(Entity entity)
    {
        Entity = entity;

        OnInit();
    }

    protected virtual void OnInit()
    {

    }
}
