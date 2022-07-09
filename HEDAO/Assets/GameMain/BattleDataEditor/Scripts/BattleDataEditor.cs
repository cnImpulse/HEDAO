using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    public class BattleDataEditor : MonoBehaviour
    {
        public GameObject GridMap = null;
        public GameObject BattleUnit = null;
        public LevelData LevelData = new LevelData();

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

            var path = AssetUtl.GetGridMapPath(LevelData.MapId);
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
            gridMap.name = string.Format("GridMap_{0}", LevelData.MapId);
        }

        [ContextMenu("SaveBattleData")]
        private void SaveBattleData()
        {
            SaveGridMap();
            SaveBattleUnitData();

            string path = AssetUtl.GetLevelDataPath(LevelData.LevelId);
            AssetUtl.SaveData(path, LevelData);
        }

        private void SaveGridMap()
        {
            var girdMap = GridMap?.transform.Find(string.Format("GridMap_{0}", LevelData.MapId));
            var tilemapList = girdMap?.GetComponentsInChildren<Tilemap>();
            if (tilemapList == null || tilemapList.Length <= 0)
            {
                return;
            }

            GridMapData gridMapData = new GridMapData();
            for (int i = tilemapList.Length - 1; i >= 0; --i)
            {
                var tileDic = GetAllTile<Grid>(tilemapList[i]);
                foreach(var pair in tileDic)
                {
                    if (gridMapData.ExitData(pair.Key))
                    {
                        continue;
                    }

                    gridMapData.SetGridData(new GridData(pair.Key, pair.Value.GridType));
                }
            }

            PrefabUtility.SaveAsPrefabAssetAndConnect(girdMap.gameObject, AssetUtl.GetGridMapPath(LevelData.MapId), InteractionMode.AutomatedAction);
            GenerateGridMap();

            string path = AssetUtl.GetGridMapDataPath(LevelData.MapId);
            AssetUtl.SaveData(path, gridMapData);
        }

        private void SaveBattleUnitData()
        {
            var battleUnitTilemap = BattleUnit?.transform.Find("m_BattleUnit")?.GetComponent<Tilemap>();
            if (battleUnitTilemap == null)
            {
                return;
            }

            LevelData.EnemyDic.Clear();
            LevelData.PlayerBrithList.Clear();
            var tileDic = GetAllTile<TileBase>(battleUnitTilemap);
            foreach (var pair in tileDic)
            {
                var tile = pair.Value;
                if (pair.Value is BattleUnitTile)
                {
                    LevelData.EnemyDic.Add(GridMapData.GridPosToIndex(pair.Key), (tile as BattleUnitTile).Id);
                }
                else if (tile.name == "brith")
                {
                    LevelData.PlayerBrithList.Add(GridMapData.GridPosToIndex(pair.Key));
                }
            }
        }

        private Dictionary<Vector2Int, T> GetAllTile<T>(Tilemap tilemap) where T : TileBase
        {
            var width = LevelData.MapWidth;
            var height = LevelData.MapHeight;
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
}
