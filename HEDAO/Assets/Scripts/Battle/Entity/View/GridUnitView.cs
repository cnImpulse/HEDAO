using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridUnitView : EntityView
{
    private long m_FloatUId = 0;

    public new GridUnit Entity => base.Entity as GridUnit;
    public GridMapView GridMapView = default;
    public Vector2Int LocalGridPos;
    
    private Animation m_Anim;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        GridMapView = data as GridMapView;
        m_Anim = GetComponentInChildren<Animation>();

        LocalGridPos = Entity.GridPos;
        
        m_FloatUId = GameMgr.UI.ShowFloatUI(UIName.FloatBattleUnit, this);
    }

    protected override void OnDestroy()
    {
        GameMgr.UI.CloseUI(m_FloatUId);
    }

    private void Update()
    {
        transform.position = GridMapUtl.GridPos2WorldPos(LocalGridPos);
    }

    public void PlayAttackAnim(Vector2Int target)
    {
        var dir = GridMapUtl.NormalizeDirection(target - LocalGridPos);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        m_Anim.Play();
    }

    public void PlayHurtAnim()
    {

    }

    public void PlayDeadAnim()
    {
        Hide();
    }

    private void InitPos()
    {
        
    }

    public void LocalMove(Vector2Int gridPos)
    {
        LocalGridPos = gridPos;
    }
}
