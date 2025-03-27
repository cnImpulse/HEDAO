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
}
