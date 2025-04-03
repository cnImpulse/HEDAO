using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleCfg
{
    public int BattleId = 0;
    public int EnemyId = 10001;
    public int EnemyNum = 4;

    public int MapId;
    [Range(2, 36)]
    public int MapWidth = 18;
    [Range(2, 36)]
    public int MapHeight = 10;
}
