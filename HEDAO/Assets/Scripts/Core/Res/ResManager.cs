using System.Collections;
using System.Collections.Generic;
using YooAsset;

public class ResManager : BaseManager
{
    protected override void OnInit()
    {
        YooAssets.Initialize();
    }
}
