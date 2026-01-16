using System;
using System.Collections.Generic;
using Cfg;
using Cfg.Battle;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuExploreNode : UIBase
{
    public Dictionary<long, PlayerRole> Team => GameMgr.Explore.Data.Team;
    public int ExploreId { get; private set; }
    public ExploreNodeCfg Cfg => GameMgr.Cfg.TbExploreNodeCfg.Get(ExploreId);
    
    public new FGUIMenuExploreNode View => base.View as FGUIMenuExploreNode;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        ExploreId = (int) userData;
        View.m_title.text = Cfg.Name;
        View.m_txt_desc.text = Cfg.Desc;
        View.m_list_option.itemRenderer = ItemRenderer;
        View.m_list_option.RefreshList(Cfg.ItemList);
    }

    private void ItemRenderer(int index, GObject item, object data)
    {
        ExploreItemCfg cfg = data as ExploreItemCfg;
        item.asButton.title = cfg.Name;
        item.asButton.onClick.Set(() =>
        {
            if (cfg.ExploreType == EExploreType.Effect)
            {
                foreach(var role in Team.Values)
                {
                    EffectCfg.TakeEffectList(cfg.EffectList, null, role);
                }
            }
            else if (cfg.ExploreType == EExploreType.Reward)
            {
                
            }
            else if (cfg.ExploreType == EExploreType.Battle)
            {
                GameMgr.Battle.StartBattle(cfg.BattleId);
            }
            
            Close();
        });
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
