using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FGUI.Common;

public class UIManager : BaseManager
{
    private Dictionary<string, UIBase> UIDict = new Dictionary<string, UIBase>();

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
    
    public void ShowUI(string uiName, object userData = default)
    {
        if (UIDict.ContainsKey(uiName))
        {
            return;
        }

        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);

        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(uiName, view, userData);

        UIDict.Add(uiName, ui);
    }

    public void CloseUI(string uiName)
    {
        if (UIDict.TryGetValue(uiName, out var ui))
        {
            ui.Dispose();
            UIDict.Remove(uiName);
        }
    }

    public void CloseAllUI()
    {
        foreach (var ui in UIDict.Values)
        {
            ui.Dispose();
        }
        UIDict.Clear();
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
