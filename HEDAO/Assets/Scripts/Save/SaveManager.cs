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
            Data = JsonConvert.DeserializeObject<SaveData>(GetSaveName(index));
        }
        else
        {
            Data = new SaveData();
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
}
