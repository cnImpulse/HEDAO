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

        Entity.Battle.OnPosChanged += OnPosChanged;
    }

    private void OnPosChanged()
    {
        GameMgr.Battle.BattleMapView.SetParent(this);
        transform.DOLocalMove(Vector3.zero, 0.5f);
    }

    protected override void OnDestroy()
    {
        Entity.Battle.OnPosChanged -= OnPosChanged;
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

    public void PlaySpineAnim(string animName, TweenCallback onComplete = null, Vector3 offset = default)
    {
        var targetPosition = GameMgr.Battle.BattleMapView.GetFxWorldPosition(this) + offset;
        var targetScale = 1.5f;
        float preTime = 0.3f, stayTime = 0.8f, endTime = 0.5f;
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, preTime));
        sequence.Insert(0, DOTween.To(
            () => GameMgr.Camera.VirtualCamera.m_Lens.OrthographicSize, 
            x => GameMgr.Camera.VirtualCamera.m_Lens.OrthographicSize = x, 
            4.8f, 
            preTime
        ));
        
        sequence.Join(transform.DOScale(targetScale, preTime));
        sequence.AppendInterval(stayTime);

        sequence.Append(transform.DOLocalMove(Vector3.zero, endTime));
        sequence.Join(transform.DOScale(Vector3.one, endTime));
        sequence.Insert(preTime + stayTime, DOTween.To(
            () => GameMgr.Camera.VirtualCamera.m_Lens.OrthographicSize, 
            x => GameMgr.Camera.VirtualCamera.m_Lens.OrthographicSize = x, 
            5.2f, 
            endTime
        ));
        
        sequence.SetAutoKill(true);

        sequence.OnStart(() => { SetSpineData(animName); });
        sequence.OnComplete(() => { 
            SetSpineData();
            onComplete?.Invoke();
        });
    }

    public void PlayDeadAnim(TweenCallback onComplete = null)
    {
        var anim = DOTween.ToAlpha(() => SkeletonAnimation.Skeleton.GetColor(),
            x => SkeletonAnimation.Skeleton.SetColor(x), 0, 0.8f);
        anim.OnComplete(onComplete);
    }
}
