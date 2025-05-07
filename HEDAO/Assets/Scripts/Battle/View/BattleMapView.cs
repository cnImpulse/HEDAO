using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BattleMapView : MonoBehaviour
{
    public List<Transform> LeftPos = new List<Transform>();
    public List<Transform> RightPos = new List<Transform>();

    public void AddBattleUnitView(BattleUnitView view)
    {
        var posIndex = view.Entity.Battle.PosIndex;
        var list = posIndex > 0 ? LeftPos : RightPos;
        view.transform.SetParent(list[Mathf.Abs(posIndex) - 1], false);
    }
}
