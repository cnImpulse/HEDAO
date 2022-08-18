using System.Collections.Generic;
using System.IO;
using GameFramework;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class SaveComponent : GameFrameworkComponent
    {
        public int SaveIndex { get; private set; } = -1;
        public SaveData SaveData { get; private set; }

        public void NewData(int index)
        {
            SaveIndex = index;
            SaveData = new SaveData();
        }

        public SaveData LoadGame(int index)
        {
            Log.Info("加载存档.");
            if (HasData(index))
            {
                SaveData = GameEntry.Setting.GetObject<SaveData>(GetSaveName(index));
            }
            else
            {
                SaveData = new SaveData();
            }
            SaveIndex = index;

            return SaveData;
        }

        public void SaveGame()
        {
            GameEntry.Setting.SetObject(GetSaveName(SaveIndex), SaveData);
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
