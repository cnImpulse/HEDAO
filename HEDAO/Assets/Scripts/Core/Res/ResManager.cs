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
    
    public IEnumerator InitPackage()
    {
        var package = YooAssets.CreatePackage("DefaultPackage");
        YooAssets.SetDefaultPackage(package);
        
        var buildinFileSystemParams = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
        var initParameters = new OfflinePlayModeParameters();
        initParameters.BuildinFileSystemParameters = null;
        var initOperation = package.InitializeAsync(initParameters);
        yield return initOperation;
    
        if(initOperation.Status == EOperationStatus.Succeed)
            Debug.Log("资源包初始化成功！");
        else 
            Debug.LogError($"资源包初始化失败：{initOperation.Error}");
    }
    
    public T LoadAsset<T>(string path)
        where T : Object
    {
        var loader = YooAssets.LoadAssetSync<T>(path);
        return loader.AssetObject as T;
    }
}
