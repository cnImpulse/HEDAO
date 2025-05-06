using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMapView : MonoBehaviour
{
    public List<Transform> PlayerPos = new List<Transform>();
    public List<Transform> EnemyPos = new List<Transform>();

    public void AddBattleUnitView(BattleUnitView view, int pos)
    {
        if (view.Entity is PlayerRole)
        {
            view.transform.SetParent(PlayerPos[pos], false);
        }
        else
        {
            view.transform.SetParent(EnemyPos[pos], false);
        }
    }
}
