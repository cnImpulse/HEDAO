using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnitView : EntityView
{
    private long m_FloatUId = 0;

    public new GridUnit Entity => base.Entity as GridUnit;
    public GridMapView GridMapView = default;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        GridMapView = data as GridMapView;

        m_FloatUId = GameMgr.UI.ShowFloatUI(UIName.FloatBattleUnit, this);
    }

    protected override void OnDestroy()
    {
        GameMgr.UI.CloseUI(m_FloatUId);
    }

    private void Update()
    {
        if (GridMapView == null) return;

        transform.position = GridMapUtl.GridPos2WorldPos(Entity.GridPos);
    }
}
