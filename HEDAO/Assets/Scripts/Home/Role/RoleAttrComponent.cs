using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Cfg;
using System;
using System.Runtime.Serialization;
using Spine.Unity.Editor;
using Range = System.Range;

public partial class RoleAttrComponent : AttrComponent
{
    public new Role Owner => base.Owner as Role;
    
    protected override void OnInit(object data)
    {
        base.OnInit(data);

        ModifyAttrDict(Owner.InitCfg.InitAttr);
        SetAttr(EAttrType.HP, GetAttrValue(EAttrType.MaxHP));
        SetAttr(EAttrType.QI, GetAttrValue(EAttrType.MaxQI));
        SetOnValueChanged(default);
        
        GetAttr(EAttrType.HP).OnValueChanged += OnHpChanged;
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

    public override HEDAO.Range GetAtkRange()
    {
        var weapon = Owner.Equip.Slot.GetItem(EEquipType.Weapon);
        if (weapon == null) return default;
        
        return weapon.Cfg.AtkRange;
    }

    public Action OnRoleHead;
    private void OnHpChanged(int value)
    {
        if (value <= 0)
        {
            OnRoleHead?.Invoke();
            GameMgr.Event.Fire(GameEventType.OnBattleUnitDead, Owner);
        }
    }
}
