using System.Collections;
using System.Collections.Generic;
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
    }
}