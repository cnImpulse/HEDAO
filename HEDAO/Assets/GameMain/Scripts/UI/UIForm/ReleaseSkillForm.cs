using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cfg.Battle;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class ReleaseSkillForm : FGUIForm<FGUIActionForm>
    {
        private SkillState m_Owner = null;
        private List<int> m_SkillList = new List<int>();

        public GList actionList => View.m_panel_action.m_list_action;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            actionList.defaultItem = FGUISkillItem.URL;
            actionList.itemRenderer = RenderListItem;

            View.m_panel_action.m_title.text = "技能";
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as SkillState;
            View.m_btn_cancel.onClick.Add(m_Owner.CancelAction);

            m_SkillList.Clear();
            foreach (var id in m_Owner.Owner.Data.RoleData.BattleSkillSet)
            {
                m_SkillList.Add(id);
            }
            actionList.numItems = m_SkillList.Count;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            View.m_btn_cancel.onClick.Clear();

            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var skillId = m_SkillList[index];
            var item = obj as FGUISkillItem;

            var skillCfg = GameEntry.Cfg.Tables.TbSkillCfg.Get(skillId);
            item.m_text_name.text = skillCfg.Name;

            var sb = new StringBuilder(100); // 预估额外需要的长度
            sb.AppendLine($"消耗:{skillCfg.Cost}");
            foreach (var effect in skillCfg.Effect)
            {
                if (effect is AttackEffect attackEffect)
                {
                    sb.AppendLine($"伤害:{attackEffect.Power}");
                }
                else if (effect is MoveEffect moveEffect)
                {
                    sb.AppendLine($"{(moveEffect.IsTarget ? "目标" : "己方")}移动:{moveEffect.Distance}");
                }
            }
            item.m_text_cost.text = sb.ToString();
            
            item.onClick.Set(() => { OnClickSkillBtn(skillId); });
        }

        private void OnClickSkillBtn(int skillId)
        {
            Log.Info("请求释放技能: {0}", skillId);
            m_Owner.OnSelectSkill(skillId);
        }
    }
}