using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapView : EntityView
{
    public new GridMap Entity => base.Entity as GridMap;

    protected override void OnInit()
    {
        base.OnInit();

        ShowAllGridUnit();
    }

    private void ShowAllGridUnit()
    {
        foreach(var gridUnit in Entity.GridUnitDict.Values)
        {
            GameMgr.Entity.ShowEntity<GridUnitView>(gridUnit);
        }
    }
}
