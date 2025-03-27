using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<Role> RandomRoleList = null;
    public Dictionary<long, Role> DiscipleList = new Dictionary<long, Role>();
    public HashSet<long> RoleTeamSet = new HashSet<long>();

    public int Year = 1;

    public SaveData()
    {

    }

    public void Init()
    {
    }
}
