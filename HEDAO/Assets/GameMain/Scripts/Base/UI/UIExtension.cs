using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.UI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class UIFromName
    {
        public const string MenuForm = "MenuForm";
        public const string SelectForm = "SelectForm";
        public const string LoadGameForm = "LoadGameForm";
    }

    public static class UIExtension
    {
        public static int OpenUIForm(this UIComponent uiComponent, string name, object data = default)
        {
            string path = AssetUtl.GetUIPath(name);
            return uiComponent.OpenUIForm(path, "Default", data);
        }

        public static void CloseUIForm(this UIComponent uiComponent, string name)
        {
            string path = AssetUtl.GetUIPath(name);
            var uiForms = uiComponent.GetAllLoadedUIForms();
            foreach(var form in uiForms)
            {
                if (form.UIFormAssetName == path)
                {
                    uiComponent.CloseUIForm(form);
                }
            }
        }
    }
}