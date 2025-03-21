using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cfg;
using Luban;
using UnityEngine;

public class CfgManager : BaseManager
{
    public Tables Tables;

    protected override void OnInit()
    {
        Tables = new Tables(LoadByteBuf);
    }

    private static ByteBuf LoadByteBuf(string file)
    {
        return new ByteBuf(File.ReadAllBytes($"{Application.dataPath}/Res/Cfg/Bytes/{file}.bytes"));
    }
}
