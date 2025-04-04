using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UnityEngine;

public class ActionSkill : ActionStateBase
{
    private List<GridData> m_Area;
    public List<int> SkillList => Owner.BattleUnit.Role.SkillSet.ToList();
    
    public override void OnEnter( )
    {
        base.OnEnter();

        View.m_panel_action.m_title.text = "术";
        
        m_list.selectionController.onChanged.Set(OnSelectSkill);
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = SkillList.Count;
        m_list.RefreshSelectionCtrl();
        m_list.ResizeToFit();
        
        GameMgr.Event.Subscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        if (m_Area != null)
        {
            var gridPos = GridMapUtl.GetMouseGridPos();
            if (m_Area.Contains(GridMap.GetGridData(gridPos)))
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
        GameMgr.Effect.HideGridEffect();
        GameMgr.Event.Unsubscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);
        
        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var cfgId = SkillList[index];
        var cfg = GameMgr.Cfg.TbSkill.Get(cfgId);
        item.text = cfg.Name;
        item.asButton.mode = ButtonMode.Radio;
        item.onClick.Set(()=>{m_list.selectedIndex = index;});
    }
    
    private void OnSelectSkill()
    {
        if (m_list.selectedIndex < 0) return;
        
        var cfgId = SkillList[m_list.selectedIndex];
        var cfg = GameMgr.Cfg.TbSkill.Get(cfgId);
        m_Area = GameMgr.Battle.Data.GridMap.GetRangeGridList(BattleUnit.GridPos, cfg.ReleaseRange);
        GameMgr.Effect.ShowGridEffect(m_Area.Select((grid)=> { return grid.GridPos; }).ToList(), Color.red);
    }
    
    private void OnPointerDownMap(GameEvent obj)
    {
        var gridData = obj.Data as GridData;
        if (m_Area.Contains(gridData))
        {
            GridUnit
        }
        else
        {
            Fsm.ChangeState<ActionSelect>();
        }
    }
}
