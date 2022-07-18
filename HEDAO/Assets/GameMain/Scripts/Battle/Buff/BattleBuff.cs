using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO.Skill
{
    public class BattleBuff : Buff
    {
        protected BattleUnit m_Owner;

        public int Life { get; protected set; } // 持续回合，默认持续到战斗结束

        public BattleBuff(int id) : base(id)
        {
            Life = -1;
        }

        public override void OnAdd(IBuffTarget owner)
        {
            base.OnAdd(owner);

            m_Owner = owner as BattleUnit;
            if (m_Owner == null)
            {
                Log.Error("BattleBuff Owner is null!");
            }
        }

        public override void OnUpdate()
        {
            if (Life > 0) --Life;
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }
    }
}