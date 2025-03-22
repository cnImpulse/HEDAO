using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager : BaseManager
{
    public SaveData Data;
    public int SaveIndex { get; private set; } = -1;

    protected override void OnInit()
    {
    }

    public void LoadGame(int index)
    {
        SaveIndex = index;
        if (HasData(index))
        {
            var json = PlayerPrefs.GetString(GetSaveName(index));
            Data = JsonConvert.DeserializeObject<SaveData>(json);
        }
        else
        {
            Data = new SaveData();
            Data.RandomRoleList = RandomGenRole(3);
            Data.Init();
            
            SaveGame();
        }
    }

    public void SaveGame()
    {
        var json = JsonConvert.SerializeObject(Data);
        PlayerPrefs.SetString(GetSaveName(SaveIndex), json);
    }

    public void DeleteData(int index)
    {
        PlayerPrefs.DeleteKey(GetSaveName(index));
    }

    public bool HasData(int index)
    {
        return PlayerPrefs.HasKey(GetSaveName(index));
    }

    public string GetSaveName(int index)
    {
        return string.Format("SaveData_{0}", index);
    }
    
    private static List<string> NameList = new List<string>() { "消炎", "叶黑", "韩跑跑" };
    private List<Role> RandomGenRole(int count)
    {
        var ret = new List<Role>(count);
        for (int i = 0; i < count; i++)
        {
            ret.Add(new Role(NameList[i]));
        }

        return ret;
    }
}
