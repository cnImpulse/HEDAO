using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData
{
    public int CfgId { get; private set; }
    public GridMap GridMap { get; private set; }

    public BattleData(int cfgId)
    {
        CfgId = cfgId;
        GridMap = new GridMap(1);
    }
}
