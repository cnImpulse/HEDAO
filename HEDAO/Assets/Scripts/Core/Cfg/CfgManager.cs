using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cfg;
using Luban;
using UnityEngine;

namespace Cfg
{
    public partial class CfgManager : BaseManager
    {
        private Tables Tables;
        protected override void OnInit()
        {
            Tables = new Tables(LoadByteBuf);
        }

        private static ByteBuf LoadByteBuf(string file)
        {
            var path = $"Assets/Res/Cfg/Bytes/{file}.bytes";
            var asset = GameMgr.Res.LoadAsset<TextAsset>(path);
            return new ByteBuf(asset.bytes);
        }
    }
}