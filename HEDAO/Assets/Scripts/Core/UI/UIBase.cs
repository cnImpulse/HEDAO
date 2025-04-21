using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public abstract class UIBase
{
    public long Id;
    public string Name { get; private set; }
    public GComponent View;

    public UIBase()
    {
        Id = GameMgr.Entity.GetNextId();
    }
    
    public void Init(string name, GComponent view, object userData)
    {
        Name = name;
        View = view;

        OnInit(userData);
        OnShow();
    }

    public void Dispose()
    {
        OnClose();
        View.Dispose();
    }
    
    public void Close()
    {
        GameMgr.UI.CloseUI(Id);
    }

    protected virtual void OnInit(object userData)
    {
        var btn = View.GetChild("btn_close")?.asButton;
        if (btn != null)
        {
            btn.onClick.Add(Close);
        }
    }

    protected virtual void OnShow()
    {

    }

    public virtual void OnUpdate()
    {
        
    }
    
    protected virtual void OnClose()
    {
        
    }

    public void Refresh()
    {
        OnShow();
    }
}
