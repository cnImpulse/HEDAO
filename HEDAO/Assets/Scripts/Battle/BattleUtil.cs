using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;

public static class BattleUtil
{
    public static ERelationType GetRelationType(GridUnit a, GridUnit b)
    {
        if (a == b)
        {
            return ERelationType.Self;
        }
        else if(a.CampType == b.CampType)
        {
            return ERelationType.Friend;
        }

        return ERelationType.Enemy;
    }

    public static ECampType GetHostileCamp(ECampType campType)
    {
        if (campType == ECampType.Enemy)
        {
            return ECampType.Player;
        }
        else if (campType == ECampType.Player)
        {
            return ECampType.Enemy;
        }

        return ECampType.None;
    }
}
