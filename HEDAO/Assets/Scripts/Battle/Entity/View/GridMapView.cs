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

    /// <summary>
    /// 网格坐标转世界坐标
    /// </summary>
    public Vector3 GridPosToWorldPos(Vector2Int gridPos)
    {
        return m_TilemapList[0].GetCellCenterWorld((Vector3Int)gridPos);
    }

    /// <summary>
    /// 世界坐标转网格坐标
    /// </summary>
    public Vector2Int WorldPosToGridPos(Vector3 worldPosition)
    {
        return (Vector2Int)m_TilemapList[0].WorldToCell(worldPosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Stage.isTouchOnUI) return;

        var gridPos = WorldPosToGridPos(eventData.pointerCurrentRaycast.worldPosition);
        GameMgr.Event.Fire(GameEventType.OnPointerDownMap, gridPos);

        Log.Info($"OnPointerDown gridPos: {gridPos}");
    }
}
