using System;
using System.Collections.Generic;
using Cfg;
using Cfg.Battle;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuDialog : UIBase
{
    public Dictionary<long, PlayerRole> Team => GameMgr.Explore.Data.Team;
    public int ExploreId { get; private set; }
    public ExploreNodeCfg Cfg => GameMgr.Cfg.TbExploreNodeCfg.Get(ExploreId);
    
    public new FGUIMenuDialog View => base.View as FGUIMenuDialog;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        ExploreId = (int) userData;
        View.m_title.text = Cfg.Name;
        View.m_txt_desc.text = Cfg.Desc;
        View.m_btn_sure.onClick.Set(() =>
        {
            if (Cfg.ExploreType == EExploreType.Effect)
            {
                foreach(var role in Team.Values)
                {
                    EffectCfg.TakeEffectList(Cfg.EffectList, null, role);
                }
            }
            else if (Cfg.ExploreType == EExploreType.Reward)
            {
                
            }
            
            Close();
        });
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
