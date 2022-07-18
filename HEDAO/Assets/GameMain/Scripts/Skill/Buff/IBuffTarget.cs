using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO.Skill
{
    public interface IBuffTarget
    {
        bool HasBuff(int buffId);

        void AddBuff(IBuff buff);

        void UpdateBuff(int buffId);

        void RemoveBuff(int buffId);
    }
}