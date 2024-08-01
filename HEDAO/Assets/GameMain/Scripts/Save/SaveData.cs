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
        public List<Role> RandomRoleList = null;
        public Dictionary<int, Role> DiscipleList = new Dictionary<int, Role>();

        public SaveData()
        {
            RandomRoleList = RandomGenRole(3);
        }
        
        private static List<string> NameList = new List<string>() { "消炎", "叶黑", "厉飞羽" };
        private List<Role> RandomGenRole(int count)
        {
            var ret = new List<Role>(count);
            for (int i = 0; i < count; i++)
            {
                ret.Add(new Role(NameList[i]));
            }

            return ret;
        }
    }
}
