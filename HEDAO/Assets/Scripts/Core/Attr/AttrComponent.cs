using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Cfg;
using System;

public class AttributeField
{
    private int m_Max = int.MaxValue;
    private int m_Value = 0;

    public int Min = int.MinValue;

    public int Max
    {
        get => m_Max;
        set
        {
            m_Max = value;
            Value = Value;
        }
    }
    
    public int Value
    {
        get => m_Value;
        set
        {
            var clamp = Mathf.Clamp(value, Min, Max);
            if (m_Value != clamp)
            {
                m_Value = clamp;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public event Action<int> OnValueChanged;

    public AttributeField(int value)
    {
        Value = value;
    }

    public void SetValueByMax()
    {
        Value = Max;
    }
}

public abstract partial class AttrComponent : Component
{
    public Dictionary<EAttrType, AttributeField> AttrDict = new Dictionary<EAttrType, AttributeField>();

    public AttrComponent()
    {
            
    }

    public void SetAttr(EAttrType type, int value)
    {
        if (!AttrDict.ContainsKey(type))
        {
            InitAttr(type, value);
            return;
        }

        AttrDict[type].Value = value;
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

    public void ModifyAttrDict(Dictionary<EAttrType, int> attrDict, bool isReset = false)
    {
        foreach(var pair in attrDict)
        {
            ModifyAttr(pair.Key, isReset ? -pair.Value : pair.Value);
        }
    }

    protected void InitAttr(EAttrType type, int value)
    {
        if (AttrDict.ContainsKey(type))
        {
            return;
        }

        AttrDict[type] = new AttributeField(value);
    }

    public AttributeField GetAttr(EAttrType type)
    {
        if (AttrDict.TryGetValue(type, out var attr))
        {
            return attr;
        }

        return null;
    }

    public int GetAttrValue(EAttrType type)
    {
        return GetAttr(type)?.Value ?? 0;
    }

    public void SetMaxByAttr(EAttrType type, EAttrType maxType)
    {
        var attr = GetAttr(type);
        if (attr == null) return;

        var maxAttr = GetAttr(maxType);
        attr.Max = maxAttr.Value;
        maxAttr.OnValueChanged += (value => attr.Max = value);
    }
}
