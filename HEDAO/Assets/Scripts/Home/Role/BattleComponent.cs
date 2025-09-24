using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class BattleComponent : Component
{
    public new Role Owner => base.Owner as Role;

    public bool IsLeft = true;
    public List<Role> TeamList;
    public int PosIndex => TeamList.IndexOf(Owner) + 1;

    public bool IsDead => Owner.Attr.HP <= 0;
    
    public Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();
    
    protected override void OnInit(object data)
    {
        base.OnInit(data);

    }

    public Action OnPosChanged;
}
