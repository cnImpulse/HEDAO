using System;
using System.Collections.Generic;
using HEDAO.Skill;
using UnityGameFramework.Runtime;
using UnityEngine;
using System.Collections;
using Cfg;
using Cfg.Battle;
using GameFramework;

namespace HEDAO
{
    /// <summary>
    /// 战斗单位。
    /// </summary>
    public partial class BattleUnit : GridUnit
    {
        public CommonAI AI { get; private set; }
        public bool CanAction { get; set; }

        public virtual void OnBattleStart()
        {
            if (Data.CampType != CampType.Player)
            {
                AI = new CommonAI(this);
            }
            
            Data.RemoveAllBuff();
        }

        public virtual void OnRoundStart()
        {
            CanAction = true;

            foreach (var buff in Data.BuffDict.Values)
            {
                buff.OnRoundStart();
            }
        }

        public virtual void OnRoundEnd()
        {
            CanAction = false;
        }

        public virtual void OnEndAction()
        {
            CanAction = false;
            GameEntry.Event.Fire(this, EventName.BattleUnitActionEnd);
        }

        public virtual void OnBattleEnd()
        {
             Data.RemoveAllBuff();
        }

        public IEnumerator Move(List<GridData> path, GridData end)
        {
            foreach (var gridData in path)
            {
                transform.position = BattleMap.GridPosToWorldPos(gridData.GridPos);
                yield return new WaitForSeconds(0.3f);
            }
            Move(end);
        }
        
        public void Move(Vector2Int end)
        {
            Move(BattleMap.Data.GetGridData(end));
        }

        public void Move(GridData end)
        {
            var start = GridData;
            if (end == null || end == start)
            {
                Log.Info("没有找到终点或终点无效!");
                return;
            }

            if (GridMapUtl.GetDistance(start, end) > Data.MOV)
            {
                Log.Error("移动力不足!");
                return;
            }
            
            BattleMap.SetGridUnitPos(this, end.GridPos);
        }
        
        public void MoveImmediate(GridData end)
        {
            var start = GridData;
            if (end == null || end == start)
            {
                Log.Info("没有找到终点或终点无效!");
                return;
            }

            BattleMap.SetGridUnitPos(this, end.GridPos);
        }

        public void TakeDamage(int damage)
        {
            int shield = Data.RoleData.BattleAttr.GetAttr(EAttrType.Shield);
            if (shield > 0)
            {
                int remainingDamage = damage - shield;
                shield = Mathf.Max(0, shield - damage);
                damage = Mathf.Max(0, remainingDamage);
        
                Data.RoleData.BattleAttr.SetAttr(EAttrType.Shield, shield);
            }
    
            Data.HP -= damage;
        }
    }
}