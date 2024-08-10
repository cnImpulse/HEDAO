using System.Collections.Generic;
using System.IO;
using GameFramework;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class SaveComponent : GameFrameworkComponent
    {
        public int SaveIndex { get; private set; } = -1;
        public SaveData PlayerData { get; private set; }

        public void NewData(int index)
        {
            SaveIndex = index;
            PlayerData = new SaveData();
        }

        public SaveData LoadGame(int index)
        {
            Log.Info("加载存档.");
            if (HasData(index))
            {
                PlayerData = GameEntry.Setting.GetObject<SaveData>(GetSaveName(index));
                SaveIndex = index;
            }
            else
            {
                PlayerData = new SaveData();
                PlayerData.RandomRoleList = RandomGenRole(3);
                SaveIndex = index;
                SaveGame();
            }

            return PlayerData;
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

        public void SaveGame()
        {
            GameEntry.Setting.SetObject(GetSaveName(SaveIndex), PlayerData);
        }

        public void DeleteData(int index)
        {
            Log.Info("删除存档.");
            GameEntry.Setting.RemoveSetting(GetSaveName(index));
        }

        public bool HasData(int index)
        {
            return GameEntry.Setting.HasSetting(GetSaveName(index));
        }

        public string GetSaveName(int index)
        {
            return string.Format("SaveData_{0}", index);
        }
    }
}
