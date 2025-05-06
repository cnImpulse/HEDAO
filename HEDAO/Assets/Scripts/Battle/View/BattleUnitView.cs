using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitView : EntityView
{
    public new Role Entity => base.Entity as Role;

    private long m_FloatUId = 0;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        m_FloatUId = GameMgr.UI.ShowFloatUI(UIName.FloatBattleUnit, this);
    }

    protected override void OnDestroy()
    {
        GameMgr.UI.CloseUI(m_FloatUId);
    }
}
