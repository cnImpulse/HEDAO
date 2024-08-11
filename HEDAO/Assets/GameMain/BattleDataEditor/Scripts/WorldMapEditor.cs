using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    public class WorldMapEditor : MonoBehaviour
    {
        public GameObject GridMap = null;
        public World World = new World();
        public int MapWidth = 50;
        public int MapHeight = 50;

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

            var path = AssetUtl.GetGridMapPath(World.MapId);
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
            gridMap.name = string.Format("GridMap_{0}", World.MapId);
        }

        [ContextMenu("SaveGridMap")]
        private void SaveGridMap()
        {
            var girdMap = GridMap?.transform.Find(string.Format("GridMap_{0}", World.MapId));
            var tilemapList = girdMap?.GetComponentsInChildren<Tilemap>();
            if (tilemapList == null || tilemapList.Length <= 0)
            {
                return;
            }

            BattleMapData battleMapData = new BattleMapData();
            for (int i = tilemapList.Length - 1; i >= 0; --i)
            {
                var tileDic = GetAllTile<GridTile>(tilemapList[i]);
                foreach(var pair in tileDic)
                {
                    if (battleMapData.ExitData(pair.Key))
                    {
                        continue;
                    }

                    battleMapData.SetGridData(new GridData(pair.Key, pair.Value.GridType));
                }
            }

            PrefabUtility.SaveAsPrefabAssetAndConnect(girdMap.gameObject, AssetUtl.GetGridMapPath(World.MapId), InteractionMode.AutomatedAction);
            GenerateGridMap();

            string path = AssetUtl.GetGridMapDataPath(World.MapId);
            AssetUtl.SaveData(path, battleMapData);
        }

        private Dictionary<Vector2Int, T> GetAllTile<T>(Tilemap tilemap) where T : TileBase
        {
            var width = MapWidth;
            var height = MapHeight;
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
