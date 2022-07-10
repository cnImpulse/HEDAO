using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.UI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class UIExtension
    {
        public static int OpenUIForm(this UIComponent uiComponent, string name, object data = default)
        {
            string path = AssetUtl.GetUIPath(name);
            return uiComponent.OpenUIForm(path, "Default", data);
        }
    }
}