using System.IO;
using GameFramework;
using Newtonsoft.Json;

namespace HEDAO
{
    public static class AssetUtl
    {
        public static string EntityPath = "Assets/GameMain/Entities";

        public static string GetLevelDataPath(int levelId)
        {
            return Utility.Text.Format("Assets/GameMain/GameData/LevelData/LevelData_{0}.json", levelId);
        }

        public static string GetGridMapPath(int mapId)
        {
            return Utility.Text.Format(EntityPath + "/GridMap/GridMap_{0}.prefab", mapId);
        }

        public static string GetGridMapDataPath(int mapId)
        {
            return Utility.Text.Format("Assets/GameMain/GameData/GridMapData/GridMapData_{0}.json", mapId);
        }

        public static string GetTilePath(string type, string image)
        {
            return Utility.Text.Format("Assets/GameMain/BattleDataEditor/Tiles/{0}/{1}.asset", type, image);
        }

        public static string GetBattleUnitPath()
        {
            return Utility.Text.Format(EntityPath + "/BattleUnit/BattleUnit.prefab");
        }

        public static string GetEffectPath(string name)
        {
            return Utility.Text.Format(EntityPath + "/Effect/{0}.prefab", name);
        }

        public static void SaveData<T>(string path, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            FileInfo file = new FileInfo(path);
            StreamWriter sw = file.CreateText();
            sw.Write(json);
            sw.Close();
            sw.Dispose();

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif

            UnityEngine.Debug.Log("保存数据成功!");
        }

        public static T ReadData<T>(string path)
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadLine();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
