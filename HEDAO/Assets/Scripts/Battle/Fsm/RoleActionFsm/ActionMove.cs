using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UnityEngine;

public class ActionMove : ActionStateBase
{
    private List<GridData> m_MoveArea;
    public List<int> MoveSkillList => Owner.BattleUnit.Role.MoveSkillSet.ToList();

    public override void OnEnter()
    {
        base.OnEnter();
        
        View.m_panel_action.m_title.text = "行";

        m_list.selectionController.onChanged.Set(OnSelectMoveSkill);
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = MoveSkillList.Count;
        m_list.RefreshSelectionCtrl();
        m_list.ResizeToFit();
        
        GameMgr.Event.Subscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        if (m_MoveArea != null)
        {
            var gridPos = GridMapUtl.GetMouseGridPos();
            if (IsSelf(GridMap.GetGridData(gridPos)) || m_MoveArea.Contains(GridMap.GetGridData(gridPos)))
            {
                var position = GridMapUtl.GridPos2WorldPos(gridPos);
                GameMgr.Effect.ShowEffect(10003, position, true);
            }
            else
            {
                GameMgr.Effect.HideEffectByPrefabId(10003);
            }
        }
    }

    public override void OnLeave()
    {
        m_MoveArea = null;
        GameMgr.Effect.HideGridEffect();
        GameMgr.Effect.HideEffectByPrefabId(10003);
        
        GameMgr.Event.Unsubscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);
        
        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var cfgId = MoveSkillList[index];
        var cfg = GameMgr.Cfg.TbMoveSkill.Get(cfgId);
        item.text = cfg.Name;
        item.asButton.mode = ButtonMode.Radio;
        item.asButton.onClick.Set(()=>{m_list.selectedIndex = index;});
    }
    
    private void OnSelectMoveSkill()
    {
        if (m_list.selectedIndex < 0) return;
        
        var cfgId = MoveSkillList[m_list.selectedIndex];
        var cfg = GameMgr.Cfg.TbMoveSkill.Get(cfgId);
        m_MoveArea = GameMgr.Battle.Data.GridMap.GetCanMoveGrids(Owner.BattleUnit, cfg.MOV);
        GameMgr.Effect.ShowGridEffect(m_MoveArea.Select((grid)=> { return grid.GridPos; }).ToList(), Color.green);
    }
    
    private void OnPointerDownMap(GameEvent obj)
    {
        var gridData = obj.Data as GridData;
        // 选中自己进入行动阶段
        if (IsSelf(gridData))
        {
            ChangeState<ActionSelect>();
            return;
        }

        // 移动
        if (m_MoveArea.Contains(gridData))
        {
            BattleUnit.Move(gridData);
            ChangeState<ActionSelect>();
        }
    }

    private bool IsSelf(GridData gridData)
    {
        return gridData == Owner.BattleUnit.GridData;
    }
}
