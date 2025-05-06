using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitView : EntityView
{
    public new Role Entity => base.Entity as Role;
}
