using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase
{
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
}
