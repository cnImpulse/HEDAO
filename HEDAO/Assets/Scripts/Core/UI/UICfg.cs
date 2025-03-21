using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class UIName
{

}

public static partial class UICfg
{
    public class UICfgItem
    {
        public Type UIType = default;
        public string UIURL = default;

        public UICfgItem(Type type, string url)
        {
            UIType = type;
            UIURL = url;
        }
    }

    private static Dictionary<string, UICfgItem> cfg = new Dictionary<string, UICfgItem>()
    {
    };

    public static UICfgItem GetCfg(string uiName)
    {
        return cfg[uiName];
    }
}
