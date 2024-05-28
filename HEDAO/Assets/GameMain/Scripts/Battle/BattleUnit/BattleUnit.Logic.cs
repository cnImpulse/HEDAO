using System.Collections.Generic;
using HEDAO.Skill;
using UnityGameFramework.Runtime;
using UnityEngine;
using System.Collections;
using Cfg.Battle;

namespace HEDAO
{
    /// <summary>
    /// 战斗单位。
    /// </summary>
    public partial class BattleUnit : GridUnit, IBuffTarget, IEffectTarget
    {
        public CommonAI AI { get; private set; }
        public Dictionary<int, BattleBuff> BuffDic { get; private set; }
        public bool CanAction { get; private set; }

        public virtual void OnBattleStart()
        {
            if (Data.CampType != CampType.Player)
            {
                AI = new CommonAI(this);
            }
            BuffDic = new Dictionary<int, BattleBuff>();
        }

        public virtual void OnRoundStart()
        {
            CanAction = true;
            UpdateAllBuff();
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
            RemoveAllBuff();
        }

        public void AddBuff(IBuff buff)
        {
            if (HasBuff(buff.Id))
            {
                RemoveBuff(buff.Id);
            }

            var battleBuff = buff as BattleBuff;
            if (battleBuff == null)
            {
                return;
            }

            BuffDic.Add(battleBuff.Id, battleBuff);
            buff.OnAdd(this);
        }

        public bool HasBuff(int buffId)
        {
            return BuffDic.ContainsKey(buffId);
        }

        public void RemoveAllBuff()
        {
            foreach (var buff in BuffDic.Values)
            {
                buff.OnRemove();
            }

            BuffDic.Clear();
        }

        public void RemoveBuff(int buffId)
        {
            if (BuffDic.TryGetValue(buffId, out var buff))
            {
                buff.OnRemove();
                BuffDic.Remove(buffId);
            }
        }

        public void UpdateAllBuff()
        {
            List<int> m_RemoveBuffList = new List<int>();
            foreach (var buff in BuffDic.Values)
            {
                buff.OnUpdate();
                if (buff.Life == 0)
                {
                    m_RemoveBuffList.Add(buff.Id);
                }
            }

            foreach(var id in m_RemoveBuffList)
            {
                RemoveBuff(id);
            }
        }

        public void UpdateBuff(int buffId)
        {
            if (BuffDic.TryGetValue(buffId, out var buff))
            {
                buff.OnUpdate();
            }
        }

        public IEnumerator Move(List<GridData> path, GridData end)
        {
            foreach (var gridData in path)
            {
                transform.position = GridMap.GridPosToWorldPos(gridData.GridPos);
                yield return new WaitForSeconds(0.3f);
            }
            Move(end);
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

            start.OnGridUnitLeave();
            end.OnGridUnitEnter(this);
            GridMap.SetGridUnitPos(this, end.GridPos);

            GameEntry.Event.Fire(this, EventName.BattleUnitMove);
        }

        public void TakeDamage(int damage)
        {
            Data.HP -= damage;
        }
    }
}