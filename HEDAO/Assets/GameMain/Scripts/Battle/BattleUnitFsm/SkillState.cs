using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class SkillState : ActionStateBase
    {
        private int m_EffectId = 0;
        private int m_SkillId = 0;
        private List<GridData> m_CanReleaseList = null;

        protected override void OnInit(IFsm<BattleUnit> fsm)
        {
            base.OnInit(fsm);

            m_ActionFormName = UIName.ReleaseSkillForm;
        }

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(EventName.PointerDownGridMap, OnPointGridMap);
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            if (m_CanReleaseList != null)
            {
                var gridPos = BattleMap.WorldPosToGridPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (m_CanReleaseList.Contains(BattleMap.Data.GetGridData(gridPos)))
                {
                    var position = BattleMap.GridPosToWorldPos(gridPos);
                    if (m_EffectId > 0)
                    {
                        GameEntry.Effect.SetEffectPos(m_EffectId, position);
                    }
                    else
                    {
                        m_EffectId = GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, position, true);
                    }
                }
                else
                {
                    GameEntry.Effect.HideEffect(m_EffectId);
                    m_EffectId = 0;
                }
            }

            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            m_SkillId = 0;
            GameEntry.Effect.HideGridEffect();
            GameEntry.Effect.HideEffect(m_EffectId);
            m_EffectId = 0;
            GameEntry.Event.Unsubscribe(EventName.PointerDownGridMap, OnPointGridMap);

            base.OnLeave(fsm, isShutdown);
        }

        public void OnSelectSkill(int skillId)
        {
            GameEntry.UI.CloseUIForm(m_ActionFormName);
            var cfg = GameEntry.Cfg.Tables.TbSkillCfg.Get(skillId);
            if (cfg.ReleaseRange.Distance == 0)
            {
                // 直接释放
                if (SkillMgr.Instance.ReleaseBattleSkill(skillId, Owner, Owner.GridData))
                {
                    ChangeState<EndActionState>();
                }
                else
                {
                    ChangeState<SkillState>();
                }
                return;
            }

            m_SkillId = skillId;
            m_CanReleaseList = BattleMap.Data.GetRangeGridList(Owner.Data.GridPos, cfg.ReleaseRange);;
            GameEntry.Effect.ShowAttackAreaEffect(m_CanReleaseList);
        }

        private void OnPointGridMap(object sender, GameEventArgs e)
        {
            if (m_SkillId == 0)
            {
                return;
            }

            var ne = e as GameEventBase;
            var gridData = ne.EventData as GridData;
            if (m_CanReleaseList.Contains(gridData))
            {
                if (SkillMgr.Instance.ReleaseBattleSkill(m_SkillId, Owner, gridData))
                {
                    ChangeState<EndActionState>();
                }
            }
            else
            {
                ChangeState<SkillState>();
            }
        }
    }
}