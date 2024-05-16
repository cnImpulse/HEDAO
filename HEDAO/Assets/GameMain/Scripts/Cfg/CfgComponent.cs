using System;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using Cfg;
using System.IO;
using Cfg.Effect;
using Luban;

namespace HEDAO
{
    public class CfgComponent : GameFrameworkComponent
    {
        public Tables Tables
        {
            get;
            private set;
        }

        public TbEffect Effect => Tables.TbEffect;
        public TbGridEffect GridEffect => Tables.TbGridEffect;

        public void InitTables()
        {
            Tables = new Tables(LoadByteBuf);
        }

        private static ByteBuf LoadByteBuf(string file)
        {
            return new ByteBuf(File.ReadAllBytes($"{Application.dataPath}/GameMain/Res/Cfg/Bytes/{file}.bytes"));
        }
    }
}
