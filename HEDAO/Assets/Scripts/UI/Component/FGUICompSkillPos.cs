using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using Cfg;
using UnityEngine;

namespace FGUI.Common
{
    public partial class FGUICompSkillPos : GComponent
    {
        public SkillCfg Cfg;

        public void Refresh(int skillId)
        {
            m_list_self.itemRenderer = OnRenderSelfPos;
            m_list_target.itemRenderer = OnRenderTargetPos;

            Cfg = GameMgr.Cfg.TbSkill.Get(skillId);
            m_list_self.numItems = 4;
            m_list_target.numItems = 4;
        }

        private void OnRenderSelfPos(int index, GObject obj, object data)
        {
            var pos = 4 - index;
            var item = obj as FGUIImgSkillPos;
            if (Cfg.LaunchPos.Contains(pos))
            {
                item.m_img_pos.url = "ui://rt51n0kjpftu6n";
            }
            else
            {
                item.m_img_pos.url = "ui://rt51n0kjpftu6m";
            }
        }

        private void OnRenderTargetPos(int index, GObject obj, object data)
        {
            var pos = index + 1;
            var item = obj as FGUIImgSkillPos;
            if (Cfg.TargetPos.Contains(pos))
            {
                item.m_img_pos.url = "ui://rt51n0kjpftu6n";
            }
            else
            {
                item.m_img_pos.url = "ui://rt51n0kjpftu6m";
            }
        }
    }
}