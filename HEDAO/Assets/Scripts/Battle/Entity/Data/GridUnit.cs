using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;

public class GridUnit : Entity
{
    public Vector2Int GridPos;
    public Role Role { get; private set; }

    public int HP => Role.Attr.GetAttrValue(EAttrType.HP);
    public int MaxHP => Role.Attr.GetAttrValue(EAttrType.MaxHP);

    protected override void OnInit(object data)
    {
        Role = data as Role;
    }

    public override int GetPrefabId()
    {
        return 10002;
    }
}
