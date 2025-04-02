using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

public class IncludeAllContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (property.Writable == false && member is PropertyInfo propertyInfo)
        {
            property.Writable = propertyInfo.GetSetMethod(true) != null;
        }

        if (property.Writable == false && member is FieldInfo fieldInfo)
        {
            property.Writable = true;
        }

        return property;
    }
}

public class SaveManager : BaseManager
{
    public SaveData Data;
    public int SaveIndex { get; private set; } = -1;

    protected override void OnInit()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new IncludeAllContractResolver()
        };
    }

    protected override void OnCleanUp()
    {
        SaveGame();

        base.OnCleanUp();
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
            Data.RandomRoleList = RandomGenRole(NameList.Count);
            Data.Init();
            
            SaveGame();
        }

        switch (Data.SceneType)
        {
            case SceneType.Home: GameMgr.Procedure.Fsm.ChangeState<ProcedureHome>(); break;
            case SceneType.Explore: GameMgr.Procedure.Fsm.ChangeState<ProcedureExplore>(); break;
            case SceneType.Battle: GameMgr.Procedure.Fsm.ChangeState<ProcedureBattle>(); break;
        }
    }

    public void SaveGame()
    {
        if (Data == null) return;
        
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
    
    private static List<string> NameList = new List<string>() { "萧一", "萧二", "萧三", "叶一", "叶二", "叶三" };
    private List<PlayerRole> RandomGenRole(int count)
    {
        var ret = new List<PlayerRole>(count);
        for (int i = 0; i < count; i++)
        {
            var role = new PlayerRole();
            role.Init(NameList[i]);
            ret.Add(role);
        }

        return ret;
    }
}
