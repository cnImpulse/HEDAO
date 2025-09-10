using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleUnitView : EntityView, IPointerClickHandler
{
    public new Role Entity => base.Entity as Role;

    protected SkeletonAnimation SkeletonAnimation;
    
    private long m_FloatUId = 0;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        SkeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        SkeletonAnimation.skeletonDataAsset = GameMgr.Res.LoadSkeletonDataAsset(Entity.InitCfg.Modle);
        SkeletonAnimation.Initialize(true);
        
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
}
