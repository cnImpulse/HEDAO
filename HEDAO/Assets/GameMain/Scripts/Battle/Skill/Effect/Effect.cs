using GameFramework;
using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public interface IEffectTarget
    {
        void AddBuff(int id)
        {
            
        }

        void RemoveBuff(int id)
        {
            
        }

        void TakeDamage(int damage)
        {
            
        }
    }
    
    public partial class Effect
    {
        public virtual void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public virtual void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }
    }
    
    public partial class MoveEffect
    {
        public static Vector2Int[] s_DirArray8 = {
            Vector2Int.down, // (0, -1)
            Vector2Int.up, // (0, 1)
            Vector2Int.left, // (-1, 0)
            Vector2Int.right, // (1, 0)
            Vector2Int.one, // (1, 1)
            new (1, -1), // (1, -1)
            new (-1, -1), // (-1, -1)
            new (-1, 1) // (-1, 1)
        };

        public static Vector2Int NormalizeDirection(Vector2Int dir)
        {
            Vector2Int normalizedDir = Vector2Int.zero;
            float maxDot = float.MinValue;

            foreach (var predefinedDir in s_DirArray8)
            {
                float dot = Vector2.Dot(dir, predefinedDir);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    normalizedDir = predefinedDir;
                }
            }

            return normalizedDir;
        }
        
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var casterUnit = caster as BattleUnit;
            var targetUnit = target as BattleUnit;
            var dir = NormalizeDirection(targetUnit.Data.GridPos - casterUnit.Data.GridPos);
            if (IsTarget)
            {
                var gridData = targetUnit.GridMap.Data.GetGridData(targetUnit.Data.GridPos + dir * Distance);
                targetUnit.Move(gridData);
            }
            else
            {
                var gridData = casterUnit.GridMap.Data.GetGridData(casterUnit.Data.GridPos + dir * Distance);
                casterUnit.Move(gridData);
            }
        }
    }
}