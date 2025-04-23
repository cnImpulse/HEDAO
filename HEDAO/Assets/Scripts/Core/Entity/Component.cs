using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Component : ObjectBase
{
    public Entity Owner;

    protected override void OnInit(object data)
    {
        Owner = data as Entity;
    }
}
