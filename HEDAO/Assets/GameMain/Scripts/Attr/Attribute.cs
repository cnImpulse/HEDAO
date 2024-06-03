using System.Collections.Generic;
using GameFramework;
using GameFramework.DataNode;
using UnityEngine;
using Newtonsoft.Json;
using UnityGameFramework.Runtime;
using Cfg;

namespace HEDAO
{
    public class AttributeField
    {
        public int m_Min = int.MinValue;
        public int m_Max = int.MaxValue;
        public int m_Value = 0;
        public int Value
        {
            get => m_Value;
            set => m_Value = Mathf.Clamp(value, m_Min, m_Max);
        }
        
        public AttributeField(int value, int min, int max)
        {
            m_Min = min;
            m_Max = max;
            Value = value;
        }
    }
    
    public class AttributeDict
    {
        private Dictionary<EAttrType, AttributeField> AttrDict = new Dictionary<EAttrType, AttributeField>();

        public AttributeDict()
        {
            
        }
        
        public void AddAttr(EAttrType type, int value, int min = int.MinValue, int max = int.MaxValue)
        {
            if (AttrDict.ContainsKey(type))
            {
                Log.Error("AttrDict has {0}", type);
                return;
            }
            
            AttrDict[type] = new AttributeField(value, min, max);
        }

        public int GetAttr(EAttrType type)
        {
            if (AttrDict.TryGetValue(type, out var attr))
            {
                return attr.Value;
            }

            return 0;
        }

        public void SetAttr(EAttrType type, int value)
        {
            AttrDict[type].Value = value;
        }

        public void ModifyAttr(EAttrType type, int value)
        {
            AttrDict[type].Value += value;
        }
    }
}