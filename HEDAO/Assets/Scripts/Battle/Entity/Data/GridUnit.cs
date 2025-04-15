using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using UnityEngine;

public enum ECampType
{
    None,
    Player,
    Enemy,
}

public class GridUnit : Entity
{
    public Vector2Int GridPos;
    public GridMap GridMap => GameMgr.Battle.Data.GridMap;
    public GridData GridData => GridMap.GetGridData(GridPos);
    public ECampType CampType { get; private set; }
    public Role Role { get; private set; }
    public CommonAI AI { get; private set; }

    public int HP => Role.Attr.GetAttrValue(EAttrType.HP);
    public int MaxHP => Role.Attr.GetAttrValue(EAttrType.MaxHP);
    public int SPD => Role.Attr.SPD;
    public int MOV
    {
        get
        {
            var id = Role.MoveSkillSet.First();
            return GameMgr.Cfg.TbMoveSkill.Get(id).MOV;
        }
    }

    protected override void OnInit(object data)
    {
        Role = data as Role;
        CampType = Role is PlayerRole ? ECampType.Player : ECampType.Enemy;
        Role.Attr.GetAttr(EAttrType.HP).OnValueChanged += OnHPChanged;
    }

    protected override void OnDestroy()
    {
        Role.Attr.GetAttr(EAttrType.HP).OnValueChanged -= OnHPChanged;

        GameMgr.Battle.Data.OnRemoveBattleUnit(Id);
        GameMgr.Entity.HideEntity(Id);
    }

    public override int GetPrefabId()
    {
        return 10002;
    }
    
    public void Move(GridData end)
    {
        GridData.OnGridUnitLeave();
        GridPos = end.GridPos;
        end.OnGridUnitEnter(this);
    }

    public IEnumerator Move(List<GridData> path, GridData end)
    {
        foreach(var gridData in path)
        {
            Move(gridData);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public bool PlaySkill(int skillId, GridData target)
    {
        return GameMgr.Battle.PlaySkill(skillId, this, target);
    }

    public void OnRoundStart()
    {
    }

    public void OnRoundEnd()
    {
        GameMgr.Battle.Data.BattleUnitQueue.Dequeue();
    }

    public void InitAI()
    {
        if (AI != null) return;

        AI = new CommonAI(this);
    }

    private void OnHPChanged(int value)
    {
        if (value <= 0)
        {
            Destroy();
        }
    }
}
