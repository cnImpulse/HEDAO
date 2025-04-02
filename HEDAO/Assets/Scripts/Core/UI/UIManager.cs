using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FGUI.Common;

public class UIManager : BaseManager
{
    private Dictionary<long, UIBase> UIDict = new Dictionary<long, UIBase>();
    private Dictionary<string, UIBase> NameDict = new Dictionary<string, UIBase>();

    protected override void OnInit()
    {
        UIPackage.AddPackage("Assets/Res/Fgui/Common");
        CommonBinder.BindAll();

        UIObjectFactory.SetPackageItemExtension("ui://rt51n0kjfbqy5v", typeof(FGUIBtnRole));
    }

    protected override void OnCleanUp()
    {
        CloseAllUI();
    }

    public void ShowFloatUI(string uiName, object userData = default)
    {
        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);
        
        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(uiName, view, userData);
        UIDict.Add(ui.Id, ui);
    }
    
    public void ShowUI(string uiName, object userData = default)
    {
        if (NameDict.ContainsKey(uiName))
        {
            return;
        }

        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);

        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(uiName, view, userData);

        UIDict.Add(ui.Id, ui);
        NameDict.Add(uiName, ui);
    }

    public void CloseUI(string uiName)
    {
        if (NameDict.TryGetValue(uiName, out var ui))
        {
            ui.Dispose();
            UIDict.Remove(ui.Id);
            NameDict.Remove(uiName);
        }
    }

    public void CloseAllUI()
    {
        foreach (var ui in UIDict.Values)
        {
            ui.Dispose();
        }
        UIDict.Clear();
        NameDict.Clear();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        foreach (var ui in UIDict.Values)
        {
            ui.OnUpdate();
        }
    }
}
