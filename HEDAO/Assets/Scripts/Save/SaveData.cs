using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string SaveName = DateTime.Now.ToShortDateString();
    public List<long> RoleList = new List<long>();
    public List<Role> RandomRoleList = null;
    public Dictionary<long, Role> DiscipleList = new Dictionary<long, Role>();
    public HashSet<long> RoleTeamSet = new HashSet<long>();

    public SaveData()
    {
            
    }

    public void Init()
    {
    }
}
