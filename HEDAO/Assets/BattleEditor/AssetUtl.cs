using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public static class AssetUtl
{
    public static string ResPath = "Assets/Res/";
    public static string EntityPath = ResPath + "Entities/";
    public static string CfgPath = ResPath + "Cfg/";
    public static string JsonCfgPath = CfgPath + "Json/";

    public static string GetBattleCfgPath(int levelId)
    {
        return string.Format(JsonCfgPath + "BattleCfg_{0}.json", levelId);
    }

    public static string GetGridMapPath(int mapId)
    {
        return string.Format(EntityPath + "GridMap/GridMap_{0}.prefab", mapId);
    }

    public static string GetGridMapDataPath(int mapId)
    {
        return string.Format(JsonCfgPath + "GridMapData_{0}.json", mapId);
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
        var txt = GameMgr.Res.LoadAsset<TextAsset>(path);
        string json = txt.text;
        Log.Info(json);

        return JsonConvert.DeserializeObject<T>(json);
    }
}
