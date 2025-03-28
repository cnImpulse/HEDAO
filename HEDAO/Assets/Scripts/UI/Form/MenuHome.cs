using System;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuHome : UIBase
{
    public new FGUIMenuHome View => base.View as FGUIMenuHome;

    private List<Role> m_RoleList;
    
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_list_building.itemRenderer = RenderListItem;
        View.m_ctrl_page.onChanged.Add(RefreshPage);
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshTime();

        var buildingCount = GameMgr.Cfg.Tables.TbBuildingCfg.DataList.Count;
        View.m_list_building.numItems = buildingCount;

        View.m_ctrl_page.ClearPages();
        for (int i = 0;i < buildingCount; i++)
        {
            View.m_ctrl_page.AddPage("");
        }
        View.m_ctrl_page.selectedIndex = 0;
    }
    
    private void RenderListItem(int index, GObject obj, object data)
    {
        var cfg = GameMgr.Cfg.Tables.TbBuildingCfg.DataList[index];
        obj.asButton.title = cfg.Name;
    }
    
    private void RefreshPage()
    {
        var index = View.m_ctrl_page.selectedIndex;
        var page = View.m_list_page.GetChildAt(index);
        if (index == 0)
        {
            var dangMoPage = page as FGUIQiuDaoPage;
            dangMoPage.Refresh();
        }
        else if (index == 1)
        {
            var bookPage = page as FGUIBookPage;
            bookPage.Refresh();
        }
        else if(index == 3)
        {
            var dangMoPage = page as FGUIDangMoPage;
            dangMoPage.Refresh();
        }
    }
    
    protected override void OnClose()
    {
        GameMgr.Save.SaveGame();

        base.OnClose();
    }

    private void RefreshTime()
    {
        View.m_txt_time.text = string.Format("天历{0}年", GameMgr.Save.Data.Year);
    }
}
