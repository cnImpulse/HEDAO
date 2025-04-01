using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager
{

    public BaseManager()
    {

    }

    public void Init()
    {
        OnInit();
    }

    protected virtual void OnInit()
    {

    }

    public void CleanUp()
    {
        OnCleanUp();
    }

    protected virtual void OnCleanUp()
    {

    }

    public virtual void OnUpdate()
    {
        
    }
}