using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public interface IBattleUnitAI
    {
        BattleUnit SelectAttackTarget();

        Vector2Int SelectMoveTarget();
    }
}