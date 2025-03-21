using System.Collections;
using System.Collections.Generic;

public class EntityData
{
    public int Id { get; private set; }

    public EntityData()
    {
        Id = GetHashCode();
    }
}
