using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Cfg.Battle;
using HEDAO.Skill;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    [JsonObject(MemberSerialization.Fields)]
    public abstract class EntityData : IEffectTarget
    {
        [JsonProperty]
        private int m_Id = 0;

        [JsonProperty]
        private string m_Name = "Entity";

        /// <summary>
        /// 实体编号。
        /// </summary>
        public int Id => m_Id;

        /// <summary>
        /// 单位名称。
        /// </summary>
        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }
        
        [JsonProperty]
        public Dictionary<int, Buff> BuffDict { get; private set; } = new();

        [JsonConstructor]
        public EntityData()
        {
            m_Id = GameEntry.Entity.GenerateSerialId();
        }
        
        public void AddBuff(int id)
        {
            RemoveBuff(id);

            var buff = new Buff(id, this);
            BuffDict.Add(id, buff);
            buff.OnAdd();
            
            Log.Info("Entity:{0}, 添加BuffId: {1}", Name, id);
        }
        
        public void RemoveBuff(int id)
        {
            if (BuffDict.TryGetValue(id, out var buff))
            {
                buff.OnRemove();
                BuffDict.Remove(id);
                
                Log.Info("移除BuffId: {0}", Name, id);
            }
        }

        public void RemoveAllBuff()
        {
            foreach (var buff in BuffDict.Values)
            {
                buff.OnRemove();
            }
            BuffDict.Clear();
        }
    }
}


