using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Linq;

public class HudBattle : UIBase
{
    public new FGUIHudBattle View => base.View as FGUIHudBattle;
    private Queue<RspBattleUnitAction> RspQueue = new Queue<RspBattleUnitAction>();
    private bool m_IsPlaying = false;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        GameMgr.Event.Subscribe(GameEventType.OnPlayerRoundStart, OnSelectBattleUnit);
        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitAction, OnBattleUnitAction);

        View.m_btn_start.onClick.Set(OnClickStart);
        View.m_list_action.itemRenderer = OnRenderRole;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        var state = GameMgr.Battle.Fsm.CurState;
        View.m_btn_start.visible = state.GetType() == typeof(BattlePrepare);
        View.m_txt_battle_state.text = state.ToString();
        RefreshActionList();
        
        UpdateBattleUnitAction();
    }

    public void UpdateBattleUnitAction()
    {
        if (RspQueue.Count == 0 || m_IsPlaying) return;

        GameMgr.Battle.GridMapView.StartCoroutine(PlayBattleUnitAction(RspQueue.Dequeue()));
    }

    public IEnumerator PlayBattleUnitAction(RspBattleUnitAction rsp)
    {
        m_IsPlaying = true;
        var effectId = GameMgr.Effect.ShowEffect(new EffectData { PrefabId = 10003, FollowId = rsp.BattleUnitId}, true);

        var view = GameMgr.Entity.GetEntityView<GridUnitView>(rsp.BattleUnitId);
        foreach (var rspAction in rsp.ActionList)
        {
            if (rspAction is MoveEvent rspMove)
            {
                yield return PlayActionMove(view, rspMove);
            }
            else if (rspAction is SkillEvent rspSkill)
            {
                yield return PlayActionSkill(view, rspSkill);
            }
            else if (rspAction is WaitEvent rspWait)
            {
                yield return PlayActionWait(view);
            }
        }

        GameMgr.Effect.HideEffect(effectId);
        m_IsPlaying = false;
    }
    
    public IEnumerator PlayActionMove(GridUnitView caster, MoveEvent e)
    {
        if (caster.Entity.CampType == ECampType.Player) yield break;
        
        foreach (var target in e.MovePath)
        {
            caster.LocalMove(target.GridPos);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public IEnumerator PlayActionSkill(GridUnitView caster, SkillEvent e)
    {
        caster.PlayAttackAnim(e.Target.GridPos);
        if (e.IsMiss)
        {
            GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {TargetId = e.Target.Id, IsMiss = true});
        }
        else
        {
            foreach (var result in e.Results)
            {
                GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {TargetId = e.Target.Id, Damage = result.Damage});
            }
        }
        yield return new WaitForSeconds(0.3f);
    }
    
    public IEnumerator PlayActionWait(GridUnitView caster)
    {
        yield return new WaitForSeconds(0.5f);
        GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
    }

    protected override void OnClose()
    {
        GameMgr.Event.Unsubscribe(GameEventType.OnPlayerRoundStart, OnSelectBattleUnit);
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleUnitAction, OnBattleUnitAction);

        base.OnClose();
    }

    public void RefreshActionList()
    {
        View.m_list_action.RefreshList(GameMgr.Battle.Data.BattleUnitQueue.ToList());
    }

    private void OnRenderRole(int index, GObject item, object data)
    {
        var role = (data as GridUnit).Role;
        var btn = item as FGUIBtnRole;
        btn.mode = ButtonMode.Common;
        btn.Refresh(role);
    }

    private void OnClickStart()
    {
        GameMgr.Battle.Fsm.ChangeState<BattleStart>();
    }
    
    private void OnSelectBattleUnit(GameEvent obj)
    {
        GameMgr.UI.ShowUI(UIName.MenuAction);
    }

    private void OnBattleUnitAction(GameEvent obj)
    {
        var e = obj.Data as RspBattleUnitAction;
        RspQueue.Enqueue(e);
    }
}
