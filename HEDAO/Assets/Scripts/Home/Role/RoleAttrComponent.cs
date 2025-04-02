using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Cfg;
using System;
using System.Runtime.Serialization;

public class RoleAttrComponent : AttrComponent
{
    public void Init(Dictionary<EAttrType, int> initAttr)
    {
        ModifyAttrDict(initAttr);

        SetAttr(EAttrType.HP, GetAttrValue(EAttrType.MaxHP));
        SetAttr(EAttrType.QI, GetAttrValue(EAttrType.MaxQI));
        SetOnValueChanged(default);
    }

    [OnDeserialized]
    public void SetOnValueChanged(StreamingContext context)
    {
        SetMaxByAttr(EAttrType.HP, EAttrType.MaxHP);
        SetMaxByAttr(EAttrType.QI, EAttrType.MaxQI);
    }

    public void OnStartExplore()
    {
        GetAttr(EAttrType.HP).SetValueByMax();
        GetAttr(EAttrType.QI).SetValueByMax();
    }
}
