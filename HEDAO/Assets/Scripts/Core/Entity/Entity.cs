using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class Entity
{
    public long Id { get; private set; }

    public Entity()
    {
        Id = GameMgr.Entity.GetNextId();
    }

    [JsonConstructor]
    public Entity(long id)
    {
        Id = id;
    }

    public void Init(object data = default)
    {
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

    public virtual int GetPrefabId()
    {
        return 0;
    }
}
