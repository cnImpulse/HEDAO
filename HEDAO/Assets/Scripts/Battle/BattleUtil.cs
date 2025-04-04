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
}
