using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class SaveData
    {
        public string SaveName = DateTime.Now.ToShortDateString();
        public List<int> RoleList = new List<int>();
        public Dictionary<int, Role> DiscipleList = new Dictionary<int, Role>();
    }
}
