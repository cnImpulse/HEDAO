using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using Cfg.Battle;
using HEDAO.Battle;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class SkillMgr : Singleton<SkillMgr>
    {
        public bool ReleaseBattleSkill(int skillId, BattleUnit caster, GridData targetGridData)
        {
            var skillCfg = GameEntry.Cfg.Tables.TbSkillCfg.GetOrDefault(skillId);
            if (skillCfg == null)
            {
                Log.Error("战斗技能{0}配置不存在!", skillId);
                return false;
            }
            
            Vector2Int dir = default;
            var center = targetGridData.GridPos;
            var target = targetGridData.GridUnit as BattleUnit;
            if (skillCfg.EffectRange.Type == EGridRangeType.Strip)
            {
                center = caster.GridData.GridPos;
                dir = GridMapUtl.NormalizeDirection(targetGridData.GridPos - caster.Data.GridPos);
            }
            else if (target == null)
            {
                return false;
            }
            
            if (caster.Data.QI < skillCfg.Cost)
            {
                Log.Error("施法者{0}灵气不足!", caster.Id);
                return false;
            }
            
            var range = caster.GridMap.Data.GetRangeGridList(center, skillCfg.EffectRange, dir);
            var targetRange = range.Where(data =>
                {
                    var battleUnit = data.GridUnit as BattleUnit;
                    if (battleUnit != null)
                    {
                        var relation = GetRelationType(caster, battleUnit);
                        return relation == skillCfg.TargetType;
                    }
                    
                    return false;
                }).Select(data => data.GridUnit as BattleUnit);

            CmdMgr.Instance.Execute(new ReleaseSkillCmd(caster, skillId, targetRange));
            
            return true;
        }

        public ERelationType GetRelationType(BattleUnit a, BattleUnit b)
        {
            if (a == b)
            {
                return ERelationType.Self;
            }

            if (a.Data.CampType == b.Data.CampType)
            {
                return ERelationType.Friend;
            }

            return ERelationType.Enemy;
        }
    }
}