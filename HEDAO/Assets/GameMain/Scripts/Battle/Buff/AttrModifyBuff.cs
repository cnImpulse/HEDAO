using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO.Skill
{
    public class AttrModifyBuff : BattleBuff
    {
        private Attribute m_ModifyAttribute;

        public AttrModifyBuff(int id) : base(id)
        {
            m_ModifyAttribute = new Attribute(10, 0);
        }

        public override void OnAdd(IBuffTarget owner)
        {
            base.OnAdd(owner);

            m_Life = 3;
            m_Owner.Data.ModifyAttribute += m_ModifyAttribute;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnRemove()
        {
            m_Owner.Data.ModifyAttribute -= m_ModifyAttribute;

            base.OnRemove();
        }
    }
}