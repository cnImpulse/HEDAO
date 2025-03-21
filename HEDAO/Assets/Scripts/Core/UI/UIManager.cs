using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FGUI.CommonUI;

public class UIManager : BaseManager
{
    private Dictionary<string, UIBase> UIDict = new Dictionary<string, UIBase>();

    protected override void OnInit()
    {
        UIPackage.AddPackage("Assets/Resources/Fgui/Common");
        CommonUIBinder.BindAll();
    }


    protected override void OnCleanUp()
    {

    }

    public void OpenUI(string uiName, object userData = default)
    {
        if (UIDict.ContainsKey(uiName))
        {
            return;
        }

        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);

        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(userData, view);

        UIDict.Add(uiName, ui);
    }

    public void CloseUI(string uiName)
    {
        if (UIDict.TryGetValue(uiName, out var ui))
        {
            ui.Close();
            UIDict.Remove(uiName);
        }
    }
}
