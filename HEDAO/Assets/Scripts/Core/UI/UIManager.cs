using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FGUI.Common;
using YooAsset;

public class UIManager : BaseManager
{
    private Dictionary<long, UIBase> m_UIDict = new Dictionary<long, UIBase>();
    private Dictionary<string, UIBase> m_NameDict = new Dictionary<string, UIBase>();
    private HashSet<long> m_WaitClose = new HashSet<long>();

    // 资源句柄列表
    private List<AssetHandle> m_Handles = new List<AssetHandle>(100);
    
    // 加载方法
    private object LoadFunc(string name, string extension, System.Type type, out DestroyMethod method)
    {
        method = DestroyMethod.None; //注意：这里一定要设置为None
        string location = $"Assets/Res/Fgui/{name}{extension}";
        var package = YooAssets.GetPackage("DefaultPackage");
        var handle = package.LoadAssetSync(location, type);
        m_Handles.Add(handle);
        return handle.AssetObject;
    }
    
    protected override void OnInit()
    {
        UIPackage.AddPackage("Common", LoadFunc);
        // UIPackage.AddPackage("Assets/Res/Fgui/Common");
        CommonBinder.BindAll();
        UIObjectFactory.SetPackageItemExtension("ui://rt51n0kjfbqy5v", typeof(FGUIBtnRole));

        UIConfig.showTips = OnClickLink;
    }
    
    protected override void OnCleanUp()
    {
        CloseAllUI();
    }

    public long ShowFloatUI(string uiName, object userData = default)
    {
        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);
        
        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(uiName, view, userData);
        m_UIDict.Add(ui.Id, ui);
        return ui.Id;
    }
    
    public void ShowUI(string uiName, object userData = default)
    {
        if (m_NameDict.ContainsKey(uiName))
        {
            return;
        }

        var uiCfg = UICfg.GetCfg(uiName);
        var view = UIPackage.CreateObjectFromURL(uiCfg.UIURL) as GComponent;
        GRoot.inst.AddChild(view);

        var ui = Activator.CreateInstance(uiCfg.UIType) as UIBase;
        ui.Init(uiName, view, userData);

        m_UIDict.Add(ui.Id, ui);
        m_NameDict.Add(uiName, ui);
    }

    public void CloseUI(string uiName)
    {
        if (m_NameDict.TryGetValue(uiName, out var ui))
        {
            m_WaitClose.Add(ui.Id);
        }
    }

    public void CloseUI(long id)
    {
        if (m_UIDict.TryGetValue(id, out var ui))
        {
            m_WaitClose.Add(ui.Id);
        }
    }

    public void CloseUImmediately(long id)
    {
        if (m_UIDict.TryGetValue(id, out var ui))
        {
            ui.Dispose();
            m_UIDict.Remove(ui.Id);
            m_NameDict.Remove(ui.Name);
        }
    }

    public void CloseAllUI()
    {
        foreach (var ui in m_UIDict.Values)
        {
            ui.Dispose();
        }
        m_UIDict.Clear();
        m_NameDict.Clear();
        m_WaitClose.Clear();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        foreach (var id in m_WaitClose)
        {
            CloseUImmediately(id);
        }

        foreach (var ui in m_UIDict.Values.ToList())
        {
            ui.OnUpdate();
        }
    }
    
    private void ReleaseHandles()
    {
        foreach(var handle in m_Handles)
        {
            handle.Release();
        }
        m_Handles.Clear();
    }

    public void OnClickLink(EventContext context)
    {
        GameMgr.UI.ShowFloatUI(UIName.FloatTips, context);
    }
}
