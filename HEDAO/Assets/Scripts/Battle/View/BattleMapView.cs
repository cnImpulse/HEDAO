using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleMapView : MonoBehaviour
{
    public Transform FxLeftRoot;
    public Transform FxRightRoot;
    public List<Transform> LeftPos = new List<Transform>();
    public List<Transform> RightPos = new List<Transform>();

    public void AddBattleUnitView(BattleUnitView view)
    {
        var posIndex = view.Entity.Battle.PosIndex;
        var list = view.Entity.Battle.IsLeft ? LeftPos : RightPos;
        view.transform.SetParent(list[posIndex - 1], false);
    }

    public Vector3 GetFxWorldPosition(BattleUnitView view)
    {
        var trans = view.Entity.Battle.IsLeft ? FxLeftRoot : FxRightRoot;
        return trans.position;
    }

    public void SetParent(BattleUnitView view)
    {
        var trans = view.Entity.Battle.IsLeft ? LeftPos : RightPos;
        view.transform.SetParent(trans[view.Entity.Battle.PosIndex - 1]);
    }
}
