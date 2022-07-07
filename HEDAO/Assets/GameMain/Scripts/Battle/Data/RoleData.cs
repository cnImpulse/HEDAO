using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class RoleData
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public string Image { get; private set; }
        public Attribute BaseAttribute { get; private set; }
        public Attribute Attribute => BaseAttribute;

        public RoleData(int roleId)
        {
            var cfg = GameEntry.Cfg.Tables.TblRoleData.Get(roleId);

            Name = cfg.Name;
            Level = 0;
            Image = cfg.Image;
            BaseAttribute = new Attribute(cfg.BaseAttribute);
        }
    }
}
