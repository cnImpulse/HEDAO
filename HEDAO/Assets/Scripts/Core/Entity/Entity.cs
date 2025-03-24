using System.Collections;
using System.Collections.Generic;

public class Entity
{
    public long Id { get; private set; }

    public Entity()
    {
        Id = GameMgr.Entity.GetNextId();
    }
}
