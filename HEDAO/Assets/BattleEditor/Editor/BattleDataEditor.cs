using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleDataEditor : MonoBehaviour
{
    public GameObject GridMap = null;
    public BattleCfg BattleCfg = new BattleCfg(); 

    [ContextMenu("GenerateGridMap")]
    private void GenerateGridMap()
    {
        if (GridMap == null)
        {
            return;
        }
    
        int childCount = GridMap.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            DestroyImmediate(GridMap.transform.GetChild(0).gameObject);
        }
    
        var path = AssetUtl.GetGridMapPath(BattleCfg.MapId);
        var mapPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (mapPrefab == null)
        {
            mapPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetUtl.GetGridMapPath(0));
        }
    
        if (mapPrefab == null)
        {
            return;
        }
    
        var gridMap = Instantiate(mapPrefab, GridMap.transform);
        gridMap.name = string.Format("GridMap_{0}", BattleCfg.MapId);
    }
    
    [ContextMenu("SaveBattleData")]
    private void SaveBattleData()
    {
        SaveGridMap();
    
        string path = AssetUtl.GetBattleCfgPath(BattleCfg.BattleId);
        AssetUtl.SaveData(path, BattleCfg);
    }
    
    private void SaveGridMap()
    {
        var girdMap = GridMap?.transform.Find(string.Format("GridMap_{0}", BattleCfg.MapId));
        var tilemapList = girdMap?.GetComponentsInChildren<Tilemap>();
        if (tilemapList == null || tilemapList.Length <= 0)
        {
            return;
        }
    
        GridMapCfg GridMapCfg = new GridMapCfg();
        for (int i = tilemapList.Length - 1; i >= 0; --i)
        {
            var map = tilemapList[i];
            var tileDic = GetAllTile<Tile>(map);
            if (map.name == "m_PlayerArea")
            {
                foreach (var pair in tileDic)
                {
                    GridMapCfg.PlayerArea.Add(pair.Key);
                }
                map.gameObject.SetActive(false);
            }
            else
            {
                foreach (var pair in tileDic)
                {
                    GridMapCfg.SetGridData(new GridData(pair.Key, 0));
                }
            }
        }
    
        PrefabUtility.SaveAsPrefabAssetAndConnect(girdMap.gameObject, AssetUtl.GetGridMapPath(BattleCfg.MapId), InteractionMode.AutomatedAction);
        GenerateGridMap();
    
        string path = AssetUtl.GetGridMapDataPath(BattleCfg.MapId);
        AssetUtl.SaveData(path, GridMapCfg);
    }
    
    private Dictionary<Vector2Int, T> GetAllTile<T>(Tilemap tilemap) where T : TileBase
    {
        var width = BattleCfg.MapWidth;
        var height = BattleCfg.MapHeight;
        Dictionary<Vector2Int, T> tileDic = new Dictionary<Vector2Int, T>();
        for (int x = -width / 2; x < width / 2; ++x)
        {
            for (int y = -height / 2; y < height / 2; ++y)
            {
                var position = new Vector2Int(x, y);
                var tile = tilemap.GetTile<T>((Vector3Int)position);
                if (tile == null)
                {
                    continue;
                }
    
                tileDic.Add(position, tile);
            }
        }
        return tileDic;
    }
    
}
