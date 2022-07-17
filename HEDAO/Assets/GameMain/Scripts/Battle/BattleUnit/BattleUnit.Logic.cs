using System.Collections.Generic;
using HEDAO.Skill;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    /// <summary>
    /// 战斗单位。
    /// </summary>
    public partial class BattleUnit : GridUnit, IBuffTarget
    {
        public Dictionary<int, IBuff> BuffDic { get; private set; }
        public bool CanAction { get; private set; }

        public virtual void OnBattleStart()
        {
            BuffDic = new Dictionary<int, IBuff>();

            AddBuff(new AttrModifyBuff(1));
            Log.Error(Data.MaxHP);
        }

        public virtual void OnRoundStart()
        {
            CanAction = true;
        }

        public virtual void OnRoundEnd()
        {
            CanAction = false;
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

            BuffDic.Add(buff.Id, buff);
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

        public void UpdateBuff(int buffId)
        {
            if (BuffDic.TryGetValue(buffId, out var buff))
            {
                buff.OnUpdate();
            }
        }
    }
}