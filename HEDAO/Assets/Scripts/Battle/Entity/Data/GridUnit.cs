using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using Cfg.Battle;
using UnityEngine;

public enum ECampType
{
    None,
    Player,
    Enemy,
}

public class GridUnit : Entity, IEffectTarget
{
    public Vector2Int GridPos;
    public GridMap GridMap => GameMgr.Battle.Data.GridMap;
    public GridData GridData => GridMap.GetGridData(GridPos);
    public ECampType CampType { get; private set; }
    public Role Role { get; private set; }
    public CommonAI AI { get; private set; }

    public AttrComponent Attr => Role.Attr;

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

    public MoveEvent Move(GridData end)
    {
        Navigator.Navigate(GridMap, this, end, out var path);
        
        GridData.OnGridUnitLeave();
        GridPos = end.GridPos;
        end.OnGridUnitEnter(this);

        return new MoveEvent { Caster = this, MovePath = path };
    }

    public WaitEvent Wait()
    {
        GameMgr.Battle.Fsm.ChangeState<BattleLoop>();
        return new WaitEvent();
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
    
    public void AddBuff(int id)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveBuff(int id)
    {
        throw new System.NotImplementedException();
    }

    public void AddSkill(int id)
    {
        throw new System.NotImplementedException();
    }

    public bool CheckCondition(int id)
    {
        throw new System.NotImplementedException();
    }
}
