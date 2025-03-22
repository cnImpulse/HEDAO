using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string SaveName = DateTime.Now.ToShortDateString();
    public List<int> RoleList = new List<int>();
    public List<Role> RandomRoleList = null;
    public Dictionary<int, Role> DiscipleList = new Dictionary<int, Role>();
    public HashSet<int> RoleTeamSet = new HashSet<int>();

    public SaveData()
    {
            
    }

    public void Init()
    {
    }
}
