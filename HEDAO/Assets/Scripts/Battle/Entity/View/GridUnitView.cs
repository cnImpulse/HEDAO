using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnitView : EntityView
{
    private long m_FloatUId = 0;

    public new GridUnit Entity => base.Entity as GridUnit;
    public GridMapView GridMapView = default;

    private Animation m_Anim;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        GridMapView = data as GridMapView;

        m_Anim = GetComponentInChildren<Animation>();

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

    public void PlayAttackAnim(GridData target)
    {
        var dir = GridMapUtl.NormalizeDirection(target.GridPos - Entity.GridPos);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        m_Anim.Play();
    }

    public void PlayHurtAnim()
    {

    }
}
