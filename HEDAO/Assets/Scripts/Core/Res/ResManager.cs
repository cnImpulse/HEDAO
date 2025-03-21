using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class ResManager : BaseManager
{
    protected override void OnInit()
    {
        YooAssets.Initialize();
    }

    public T LoadAsset<T>(string path)
        where T : Object
    {
        return YooAssets.LoadAssetSync<T>(path).AssetObject as T;
    }
}
