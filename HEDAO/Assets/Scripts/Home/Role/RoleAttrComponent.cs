using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Cfg;
using System;
    
public class RoleAttrComponent : AttrComponent
{
    public void Init(Role role)
    {
        ModifyAttrDict(role.Cfg.InitAttr);

        SetAttr(EAttrType.HP, GetAttrValue(EAttrType.MaxHP));
        SetAttr(EAttrType.QI, GetAttrValue(EAttrType.MaxQI));
        SetMaxByAttr(EAttrType.HP, EAttrType.MaxHP);
        SetMaxByAttr(EAttrType.QI, EAttrType.MaxQI);
    }

    public void OnStartExplore()
    {
        GetAttr(EAttrType.HP).SetValueByMax();
        GetAttr(EAttrType.QI).SetValueByMax();
    }
}
