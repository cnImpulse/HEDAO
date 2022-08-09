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
        protected override void OnInit(IFsm<BattleUnit> fsm)
        {
            base.OnInit(fsm);

            m_ActionFormName = UIFromName.ReleaseSkillForm;
        }

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        public void ReqReleaseSkill(int skillId)
        {
            //GameEntry.UI.CloseUIForm(m_SerilId);
            //m_SkillId = skillId;
            //m_CanReleaseList = m_GridMap.Data.GetSkillReleaseRange(Owner, m_SkillId);
            //m_GridMap.ShowAttackArea(m_CanReleaseList);
            //GameEntry.Battle.SetAreaSelectEffect(m_CanReleaseList.ConvertAll((input) => input.GridPos), m_GridMap);
        }

        //private void OnPointGridMap(object sender, GameEventArgs e)
        //{
        //    var ne = e as GameEventBase;
        //    var gridData = ne.UserData as GridData;
        //    var gridUnit = gridData.GridUnit;
        //    if (m_CanReleaseList.Contains(gridData))
        //    {
        //        if (gridUnit == null || !(gridUnit is BattleUnit))
        //        {
        //            return;
        //        }

        //        if (GameEntry.Skill.RequestReleaseSkill(m_SkillId, Owner.Id, gridUnit.Id))
        //        {
        //            ChangeState<EndActionState>();
        //        }
        //    }
        //    else
        //    {
        //        ChangeState<SkillState>();
        //    }
        //}
    }
}