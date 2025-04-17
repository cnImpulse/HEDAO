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

        var buildResult = EditorSimulateModeHelper.SimulateBuild("DefaultPackage");
        var packageRoot = buildResult.PackageRootDirectory;
        var editorFileSystemParams = FileSystemParameters.CreateDefaultEditorFileSystemParameters(packageRoot);
        var initParameters = new EditorSimulateModeParameters();
        initParameters.EditorFileSystemParameters = editorFileSystemParams;
        var initOperation = package.InitializeAsync(initParameters);
        yield return initOperation;

        yield return RequestAndUpdate(package);
    }

    public IEnumerator InitPackageRuntime()
    {
        var package = YooAssets.CreatePackage("DefaultPackage");
        YooAssets.SetDefaultPackage(package);
        
        var buildinFileSystemParams = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
        var initParameters = new OfflinePlayModeParameters();
        initParameters.BuildinFileSystemParameters = buildinFileSystemParams;

        var initOperation = package.InitializeAsync(initParameters);
        yield return initOperation;
        
        if(initOperation.Status == EOperationStatus.Succeed)
            Debug.Log("资源包初始化成功！");
        else 
            Debug.LogError($"资源包初始化失败：{initOperation.Error}");

        yield return RequestAndUpdate(package);
    }

    public IEnumerator RequestAndUpdate(ResourcePackage package)
    {
        var operation2 = package.RequestPackageVersionAsync();
        yield return operation2;
        if (operation2.Status != EOperationStatus.Succeed) yield break;

        var operation3 = package.UpdatePackageManifestAsync(operation2.PackageVersion);
        yield return operation3;
        if (operation3.Status != EOperationStatus.Succeed) yield break;

        if (operation3.Status == EOperationStatus.Succeed)
            Debug.Log("资源包初始化成功！");
        else
            Debug.LogError($"资源包初始化失败：{operation2.Error}");
    }
    
    public T LoadAsset<T>(string path)
        where T : Object
    {
        var handle = YooAssets.LoadAssetSync<T>(path);
        if (handle.AssetObject is GameObject)
        {
            return handle.InstantiateSync() as T;
        }
        
        return handle.AssetObject as T;
    }
    
    public T LoadAsset<T>(int prefabId)
        where T : Object
    {
        var path = GameMgr.Cfg.TbRes.Get(prefabId).Path;
        return LoadAsset<T>(path);
    }
}
