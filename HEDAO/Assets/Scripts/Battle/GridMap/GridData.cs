using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridData
{
    public int CfgId { get; private set; }
    public Vector2Int GridPos { get; private set; }
    public int GridIndex => GridMapUtl.GridPosToIndex(GridPos);

    public GridData(Vector2Int position, int cfgId)
    {
        GridPos = position;
    }

    /// <summary>
    /// 占据的网格单位
    /// </summary>
    public GridUnit GridUnit { get; private set; }

    public void OnGridUnitEnter(GridUnit gridUnit)
    {
        if (GridUnit != null)
        {
            Log.Error("单元格已经被占据,无法进入!");
            return;
        }

        GridUnit = gridUnit;
    }

    public void OnGridUnitLeave()
    {
        if (GridUnit == null)
        {
            Log.Error("没有单位占据该单元格!");
            return;
        }

        GridUnit = null;
    }

    // /// <summary>
    // /// 是否可以经过
    // /// </summary>
    // /// <param name="战斗单位数据"></param>
    // public bool CanAcross(BattleUnit battleUnit)
    // {
    //     if (battleUnit == null)
    //     {
    //         return false;
    //     }
    //
    //     if (GridType == GridType.Obstacle)
    //     {
    //         return false;
    //     }
    //
    //     if (GridUnit != null && GridUnit.Data.CampType != battleUnit.Data.CampType)
    //     {
    //         return false;
    //     }
    //
    //     return true;
    // }
    //
    // /// <summary>
    // /// 是否可以到达
    // /// </summary>
    // public bool CanArrive()
    // {
    //     if (GridType == GridType.Obstacle || GridUnit != null)
    //     {
    //         return false;
    //     }
    //
    //     return true;
    // }
}
