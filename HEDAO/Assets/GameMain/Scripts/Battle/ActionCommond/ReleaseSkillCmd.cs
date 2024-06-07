using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;

namespace HEDAO
{
    public class ReleaseSkillCmd : Command
    {
        private int m_SkillId = 0;
        private IEnumerable<BattleUnit> m_TargetList = default;
        
        public ReleaseSkillCmd(BattleUnit battleUnit, int skillId, IEnumerable<BattleUnit> targetList) : base(battleUnit)
        {
            m_SkillId = skillId;
            m_TargetList = targetList;
        }

        public override void Redo()
        {
            var skillCfg = GameEntry.Cfg.Tables.TbSkillCfg.GetOrDefault(m_SkillId);
            foreach (var effect in skillCfg.Effect)
            {
                if (effect.TargetType == EEffectTargetType.None)
                {
                    foreach (var battleUnit in m_TargetList)
                    {
                        effect.OnTakeEffect(Owner, battleUnit);
                    }
                }
                else if (effect.TargetType == EEffectTargetType.Caster)
                {
                    effect.OnTakeEffect(Owner, Owner);
                }
            }

            Owner.Data.QI -= skillCfg.Cost;
        }

        public override void Undo()
        {
            var skillCfg = GameEntry.Cfg.Tables.TbSkillCfg.GetOrDefault(m_SkillId);
            Owner.Data.QI += skillCfg.Cost;
            
            foreach (var effect in skillCfg.Effect)
            {
                if (effect.TargetType == EEffectTargetType.None)
                {
                    foreach (var battleUnit in m_TargetList)
                    {
                        effect.OnResetEffect(Owner, battleUnit);
                    }
                }
                else if (effect.TargetType == EEffectTargetType.Caster)
                {
                    effect.OnResetEffect(Owner, Owner);
                }
            }
        }
    }
}
