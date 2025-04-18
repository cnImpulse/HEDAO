using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
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
            if (IsSelfPos(gridPos) || m_MoveArea.Contains(GridMap.GetGridData(gridPos)))
            {
                var position = GridMapUtl.GridPos2WorldPos(gridPos);
                GameMgr.Effect.ShowEffect(new EffectData { PrefabId = 10003, Position = position}, true);
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
        var cfg = GetSelectMoveCfg();
        if (cfg == null) return;

        m_MoveArea = GameMgr.Battle.Data.GridMap.GetCanMoveGrids(Owner.BattleUnit, cfg.MOV);
        GameMgr.Effect.ShowGridEffect(m_MoveArea.Select((grid)=> { return grid.GridPos; }).ToList(), Color.green);

        RefreshInfo();
    }
    
    private void OnPointerDownMap(GameEvent obj)
    {
        var gridData = obj.Data as GridData;
        // 选中自己进入行动阶段
        if (IsSelfPos(gridData.GridPos))
        {
            ChangeState<ActionSelect>();
            return;
        }

        // 移动
        if (m_MoveArea.Contains(gridData))
        {
            GridMapView.StartCoroutine(Move(gridData));
        }
    }

    public IEnumerator Move(GridData end)
    {
        View.m_panel_action.visible = false;
        GameMgr.Event.Unsubscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);

        Navigator.Navigate(GridMap, BattleUnit, end, out var path);
        foreach (var target in path)
        {
            BattleUnitView.LocalMove(target.GridPos);
            yield return new WaitForSeconds(0.3f);
        }

        Owner.Req.ReqActionList.Add(new ReqMove { End = end });
        View.m_panel_action.visible = true;
        ChangeState<ActionSelect>();
    }

    private bool IsSelfPos(Vector2Int pos)
    {
        return pos == BattleUnitView.LocalGridPos;
    }

    private void RefreshInfo()
    {
        var cfg = GetSelectMoveCfg();
        if (cfg == null) return;

        m_txt_info.title = string.Format("移动力: {0}", cfg.MOV);
    }

    private MoveSkillCfg GetSelectMoveCfg()
    {
        if (m_list.selectedIndex < 0) return null;

        var cfgId = MoveSkillList[m_list.selectedIndex];
        var cfg = GameMgr.Cfg.TbMoveSkill.Get(cfgId);
        return cfg;
    }
}
