using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnit : Entity
{
    public Vector2Int GridPos;
    public Role Role { get; private set; }

    protected override void OnInit(object data)
    {
        Role = data as Role;
    }

    public override int GetPrefabId()
    {
        return 10002;
    }
}
