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

        var buildingCount = GameMgr.Cfg.Tables.TbBuildingCfg.DataList.Count;
        View.m_list_building.numItems = buildingCount;

        View.m_ctrl_page.ClearPages();
        for (int i = 0;i < buildingCount; i++)
        {
            View.m_ctrl_page.AddPage("");
        }
        View.m_ctrl_page.selectedIndex = 0;
    }
    
    private void RenderListItem(int index, GObject obj)
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
            var qiudao = page as FGUIQiuDaoPage;
            qiudao.m_btn_get.asButton.onClick.Set(() => { OnClickBtnGet(qiudao);});
        
            m_RoleList = GameMgr.Save.Data.RandomRoleList;
            qiudao.visible = m_RoleList.Count != 0;
            if (m_RoleList.Count == 0)
            {
                return;
            }
        
            var ctrl = qiudao.m_list_role.m_ctrl_select;
            ctrl.ClearPages();
            ctrl.onChanged.Clear();
            ctrl.onChanged.Add(() => { OnRoleChanged(qiudao);});
                
            qiudao.m_list_role.m_list.itemRenderer = OnRenderRole;
            qiudao.m_list_role.m_list.numItems = m_RoleList.Count;
        
            for (int i = 0; i < 3; i++)
            {
                ctrl.AddPage("");
            }
            ctrl.selectedIndex = 0;
        }
        else if(index == 3)
        {
            var dangMoPage = page as FGUIDangMoPage;
            dangMoPage.RefreshPage();
        }
    }
    
    private void OnClickBtnGet(FGUIQiuDaoPage qiuDaoPage)
    {
        var selectIndex = qiuDaoPage.m_list_role.m_ctrl_select.selectedIndex;
        if (selectIndex < 0)
        {
            return;
        }

        var role = m_RoleList[selectIndex];
        GameMgr.Save.Data.DiscipleList.Add(role.Id, role);
            
        m_RoleList.RemoveAt(selectIndex);
        qiuDaoPage.m_list_role.m_ctrl_select.selectedIndex = 0;
        qiuDaoPage.m_list_role.m_list.numItems = m_RoleList.Count;
    }
    
    private void OnRenderRole(int index, GObject obj)
    {
        var role = m_RoleList[index];
        obj.asButton.title = role.Name;
    }

    private static List<EAttrType> AttrList = new List<EAttrType>()
    {
        EAttrType.MaxHP, EAttrType.MaxQI, EAttrType.SPD, EAttrType.STR,
        EAttrType.TPO, EAttrType.SSI, EAttrType.FAS
    };
    private void OnRoleChanged(FGUIQiuDaoPage qiuDaoPage)
    {
        var selectIndex = qiuDaoPage.m_list_role.m_ctrl_select.selectedIndex;
        if (selectIndex < 0)
        {
            return;
        }

        var role = m_RoleList[selectIndex];
        var attr = role.BattleAttr;
        var info = $"姓名：{role.Name}\n";
        info += $"年龄：{attr.GetAttr(EAttrType.Age)} 寿命：{attr.GetAttr(EAttrType.Life)}\n";
        foreach (var attrType in AttrList)
        {
            info += $"{attrType.GetName()}：{attr.GetAttr(attrType)} \n";
        }

        qiuDaoPage.m_text_role.text = info;

        float[] arr = new float[5];
        foreach (var pair in role.WuXin)
        {
            var index = (int)pair.Key;
            var value = pair.Value / 100f;
            arr[index] = value;
            var text = qiuDaoPage.m_rader.GetChildAt(
                qiuDaoPage.m_rader.GetChildIndex(qiuDaoPage.m_rader.m_text_wuxin_0) + index);
            text.text = $"{pair.Key.GetName()}：{pair.Value}";
        }
            
        qiuDaoPage.m_rader.m_img_wuxing.shape.DrawRegularPolygon(5, 4, Color.white, 
            Color.black, Color.white, 54, arr);
    }
}
