using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleUnitView : EntityView, IPointerClickHandler
{
    public new Role Entity => base.Entity as Role;

    protected Animation Animation;
    protected SkeletonAnimation SkeletonAnimation;
    
    private long m_FloatUId = 0;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        Animation = GetComponentInChildren<Animation>();
        SkeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        SetSpineData("combat");
        
        m_FloatUId = GameMgr.UI.ShowFloatUI(UIName.FloatBattleUnit, this);
    }

    protected override void OnDestroy()
    {
        GameMgr.UI.CloseUI(m_FloatUId);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FairyGUI.Stage.isTouchOnUI)
        {
            return;
        }

        GameMgr.Event.Fire(GameEventType.OnClickBattleUnit, this);
    }

    public void PlayAnim(string animName)
    {
        Animation.Play(animName);
    }

    public void SetSpineData(string animName = "combat")
    {
        SkeletonAnimation.skeletonDataAsset = GameMgr.Res.LoadSkeletonDataAsset(Entity.InitCfg.Modle, animName);
        SkeletonAnimation.Initialize(true);
    }

    public void PlaySpineAnim(string animName)
    {
        var targetPosition = GameMgr.Battle.BattleMapView.GetFxWorldPosition(this);
        var targetScale = 1.5f;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, 0.3f));
        sequence.Join(transform.DOScale(targetScale, 0.3f)); 

        sequence.AppendInterval(0.8f);

        sequence.Append(transform.DOLocalMove(Vector3.zero, 0.5f));
        sequence.Join(transform.DOScale(Vector3.one, 0.5f));
        sequence.SetAutoKill(true);

        sequence.OnStart(() => { SetSpineData(animName); });
        sequence.OnComplete(() => { SetSpineData(); });
    }
}
