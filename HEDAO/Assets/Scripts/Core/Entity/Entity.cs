using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class Entity : ObjectBase
{
    public long Id { get; private set; }
    public Dictionary<string, Component> Components = new Dictionary<string, Component>();

    public Entity()
    {
        Id = GameMgr.Entity.GetNextId();
    }

    [JsonConstructor]
    public Entity(long id)
    {
        Id = id;
    }

    public void AddComponent<T>()
        where T : Component, new()
    {
        var component = new T();
        Components.TryAdd(typeof(T).ToString(), component);
        component.Init(this);
    }

    public T GetComponent<T>()
        where T : Component
    {
        if (Components.TryGetValue(typeof(T).ToString(), out var component))
        {
            return component as T;
        }

        return default;
    }

    public virtual int GetPrefabId()
    {
        return 0;
    }
}
