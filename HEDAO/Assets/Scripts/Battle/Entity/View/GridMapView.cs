using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridMapView : EntityView, IPointerDownHandler
{
    public new GridMap Entity => base.Entity as GridMap;

    protected Tilemap[] m_TilemapList = null;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        m_TilemapList = GetComponentsInChildren<Tilemap>();
        m_TilemapList[0].gameObject.AddComponent<BoxCollider2D>();

        ShowAllGridUnit();
    }

    private void ShowAllGridUnit()
    {
        foreach(var gridUnit in Entity.GridUnitDict.Values)
        {
            GameMgr.Entity.ShowEntity<GridUnitView>(gridUnit, this);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Stage.isTouchOnUI) return;

        var gridPos = GridMapUtl.WorldPos2GridPos(eventData.pointerCurrentRaycast.worldPosition);
        GameMgr.Event.Fire(GameEventType.OnPointerDownMap, gridPos);

        Log.Info($"OnPointerDown gridPos: {gridPos}");
    }
}
