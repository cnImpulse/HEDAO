using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnitView : EntityView
{
    public new GridUnit Entity => base.Entity as GridUnit;
    public GridMapView GridMapView = default;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        GridMapView = data as GridMapView;
        
        GameMgr.UI.ShowFloatUI(UIName.FloatBattleUnit, this);
    }

    private void Update()
    {
        if (GridMapView == null) return;

        transform.position = GridMapView.GridPosToWorldPos(Entity.GridPos);
    }
}
