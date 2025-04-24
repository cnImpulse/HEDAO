using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using Cfg;

public class MenuBattleEnd : UIBase
{
    public new FGUIMenuBattleEnd View => base.View as FGUIMenuBattleEnd;
    public BattleEndEvent BattleResult;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        BattleResult = userData as BattleEndEvent;

        View.m_btn_sure.onClick.Set(OnClickSure);
        View.m_txt_result.text = BattleResult.Result.GetName();

        View.m_list_item.itemRenderer = OnRenderItem;
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_list_item.RefreshList(BattleResult.ItemList);
    }

    private void OnClickSure()
    {
        GameMgr.Save.Data.HomeData.Store.AddItems(BattleResult.ItemList);
        GameMgr.Battle.EndBattle();
    }

    private void OnRenderItem(int index, GObject obj, object data)
    {
        var item = data as ItemData;
        var ctrl = obj.asButton;

        ctrl.title = item == null ? "" : item.Cfg.Name;
        ctrl.onClick.Set((e) => OnClickItem(e, item));
    }

    private void OnClickItem(EventContext e, ItemData item)
    {
        if (item == null) return;

        var param = new FloatItemTipsParams();
        param.Item = item;
        param.Postion = e.inputEvent.position;

        GameMgr.UI.ShowUI(UIName.FloatItemTips, param);
    }
}
