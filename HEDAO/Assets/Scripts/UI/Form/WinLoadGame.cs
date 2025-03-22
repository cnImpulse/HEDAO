using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class WinLoadGame : UIBase
{
    public new FGUIWinLoadGame View => base.View as FGUIWinLoadGame;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_list.itemRenderer = OnRenderList;
    }

    private void OnRenderList(int index, GObject obj)
    {
        var item = obj as FGUISaveItem;
        if (GameMgr.Save.HasData(index))
        {
            item.m_btn_load.title = GameMgr.Save.GetSaveName(index);
            item.m_btn_clear.onClick.Set(()=>OnClickClear(index));
        }
        else
        {
            item.m_btn_load.title = "空";
        }
        
        item.m_btn_load.onClick.Set(()=>OnClickLoad(index));
    }

    private void OnClickClear(int index)
    {
        GameMgr.Save.DeleteData(index);
        View.m_list.RefreshList();
    }

    private void OnClickLoad(int index)
    {
        GameMgr.Save.LoadGame(index);
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_list.numItems = 3;
    }
}
