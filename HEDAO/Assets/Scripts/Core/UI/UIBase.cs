using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public abstract class UIBase
{
    public GComponent View;

    public void Init(object userData, GComponent view)
    {
        View = view;
        OnInit(userData);
        OnShow();
    }

    public void Close()
    {
        OnDestroy();

        View.Dispose();
    }

    protected virtual void OnInit(object userData)
    {
        
    }

    protected virtual void OnShow()
    {

    }

    protected virtual void OnDestroy()
    {
        
    }
}
