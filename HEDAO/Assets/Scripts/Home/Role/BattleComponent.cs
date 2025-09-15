using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class BattleComponent : Component
{
    public new Role Owner => base.Owner as Role;

    public int PosIndex = 0;
    public bool IsLeft = true;

    protected override void OnInit(object data)
    {
        base.OnInit(data);


    }
}
