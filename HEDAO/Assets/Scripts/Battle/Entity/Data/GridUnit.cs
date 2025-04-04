using System.Collections;
using System.Collections.Generic;
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

    public int HP => Role.Attr.GetAttrValue(EAttrType.HP);
    public int MaxHP => Role.Attr.GetAttrValue(EAttrType.MaxHP);
    public int SPD => Role.Attr.SPD;

    protected override void OnInit(object data)
    {
        Role = data as Role;
        CampType = Role is PlayerRole ? ECampType.Player : ECampType.Enemy;
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

    public bool PlaySkill(int skillId, GridData target)
    {
        return GameMgr.Battle.PlaySkill(skillId, this, target);
    }

    public void OnRoundStart()
    {
    }

    public void OnRoundEnd()
    {

    }
}
