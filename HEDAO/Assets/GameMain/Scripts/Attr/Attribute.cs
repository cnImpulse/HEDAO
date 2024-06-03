using System.Collections.Generic;
using GameFramework;
using GameFramework.DataNode;
using UnityEngine;
using Newtonsoft.Json;
using UnityGameFramework.Runtime;
using Cfg;

namespace HEDAO
{
    public class AttributeDict
    {
        private Dictionary<EAttrType, Variable> AttrDict = new Dictionary<EAttrType, Variable>();

        public AttributeDict()
        {
            
        }
        
        public void AddAttr(EAttrType type, Variable value)
        {
            if (AttrDict.ContainsKey(type))
            {
                Log.Error("AttrDict has {0}", type);
                return;
            }
            
            AttrDict[type] = value;
        }

        public T GetAttr<T>(EAttrType type)
        {
            if (AttrDict.TryGetValue(type, out var attr))
            {
                return (T) attr.GetValue();
            }

            return default;
        }

        public void SetAttr<T>(EAttrType type, T value)
        {
            AttrDict[type].SetValue(value);
        }

        public void ModifyAttr<T>(EAttrType type, T value)
            where T : Variable
        {
            if (AttrDict.TryGetValue(type, out var attr))
            {
                attr.SetValue((dynamic) attr.GetValue() + (dynamic) value.GetValue());
            }
            else
            {
                AddAttr(type, value);
            }
        }
    }
}