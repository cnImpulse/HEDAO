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
    protected Entity(long id)
    {
        Id = id;
    }

    public void Init(object data = default)
    {
        OnInit(data);
    }

    protected virtual void OnInit(object data)
    {

    }

    public virtual int GetPrefabId()
    {
        return 0;
    }
}
