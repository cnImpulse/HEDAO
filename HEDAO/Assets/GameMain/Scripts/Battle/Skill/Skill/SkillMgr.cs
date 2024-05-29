using System.Collections;
using System.Collections.Generic;
using Cfg;
using Cfg.Battle;
using HEDAO.Battle;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class SkillMgr : Singleton<SkillMgr>
    {
        public bool ReqReleaseBattleSkill(int skillId, int casterId, int targetId)
        {
            var skillCfg = GameEntry.Cfg.Tables.TbBattleSkillCfg.GetOrDefault(skillId);
            if (skillCfg == null)
            {
                Log.Error("战斗技能{0}配置不存在!", skillId);
                return false;
            }

            var target = GameEntry.Entity.GetEntityData<BattleUnitData>(targetId);
            if (target == null)
            {
                Log.Error("目标{0}不存在!", targetId);
                return false;
            }

            var caster = GameEntry.Entity.GetEntityData<BattleUnitData>(casterId);
            if (caster == null)
            {
                Log.Error("施法者{0}不存在!", casterId);
                return false;
            }

            if (caster.QI < skillCfg.Cost)
            {
                Log.Error("施法者{0}灵气不足!", casterId);
                return false;
            }

            caster.QI -= skillCfg.Cost;
            target.HP -= skillCfg.Power;

            string log = string.Format("{0}释放技能{1}, 对{2}造成{3}点伤害.", caster.Name, skillCfg.Name, target.Name, skillCfg.Power);
            GameEntry.UI.OpenUIForm(UIFromName.CommonTips, log as object);
            Log.Info(log);
            return true;
        }

        public bool ReleaseBattleSkill(int skillId, BattleUnit caster, GridData targetGridData)
        {
            var skillCfg = GameEntry.Cfg.Tables.TbSkillCfg.GetOrDefault(skillId);
            if (skillCfg == null)
            {
                Log.Error("战斗技能{0}配置不存在!", skillId);
                return false;
            }
            
            Vector2Int dir = default;
            var target = targetGridData.GridUnit as BattleUnit;
            if (skillCfg.EffectRange.Type == EGridRangeType.Strip)
            {
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
            
            caster.Data.QI -= skillCfg.Cost;
            
            var targetCamp = BattleUtl.GetHostileCamp(caster.Data.CampType);
            var range = caster.GridMap.Data.GetRangeGridList(targetGridData.GridPos, skillCfg.EffectRange, dir);
            foreach (var gridData in range)
            {
                var battleUnit = gridData.GridUnit as BattleUnit;
                if (battleUnit != null && battleUnit.Data.CampType == targetCamp)
                {
                    foreach (var effect in skillCfg.Effect)
                    {
                        effect.OnTakeEffect(caster, gridData.GridUnit as BattleUnit);
                    }
                }
            }
            
            return true;
        }
    }
}