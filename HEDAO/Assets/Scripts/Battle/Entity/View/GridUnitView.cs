using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnitView : EntityView
{
    public new GridUnit Entity => base.Entity as GridUnit;

    protected override void OnInit()
    {
        base.OnInit();

    }

    private void Update()
    {
        transform.position = GridMapUtl.GridPos2WorldPos(Entity.GridPos);
    }
}
