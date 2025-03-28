using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Cfg;


[JsonObject(MemberSerialization.Fields)]
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

    public int Max => m_Max;
        
    public AttributeField(int value, int min, int max)
    {
        m_Min = min;
        m_Max = max;
        Value = value;
    }
}
    
[JsonObject(MemberSerialization.Fields)]
public class AttributeDict
{
    private Dictionary<EAttrType, AttributeField> AttrDict = new Dictionary<EAttrType, AttributeField>();

    public AttributeDict()
    {
            
    }

    public void ModifyAttrDict(Dictionary<EAttrType, int> attrDict)
    {
        foreach(var pair in attrDict)
        {
            ModifyAttr(pair.Key, pair.Value);
        }
    }

    public void ModifyAttr(EAttrType type, int value)
    {
        if (!AttrDict.ContainsKey(type))
        {
            InitAttr(type, value);
            return;
        }

        AttrDict[type].Value += value;
    }

    public void InitAttr(EAttrType type, int value, int min = int.MinValue, int max = int.MaxValue)
    {
        if (AttrDict.ContainsKey(type))
        {
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
}
