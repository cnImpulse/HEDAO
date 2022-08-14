using System;
using System.Collections.Generic;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class UIFromName
    {
        public const string MenuForm = "MenuForm";
        public const string SelectForm = "SelectForm";
        public const string LoadGameForm = "LoadGame";
        public const string BattleForm = "BattleForm";
        public const string ActionForm = "ActionForm";
        public const string ReleaseSkillForm = "ReleaseSkillForm";
    }

    public static class UICfg
    {
        private static Dictionary<string, UICfgItem> cfg = new Dictionary<string, UICfgItem>()
        {
            [UIFromName.MenuForm]           = new UICfgItem(typeof(MenuForm),         UIFromName.MenuForm,         FGUIMenuForm.URL),
            [UIFromName.SelectForm]         = new UICfgItem(typeof(SelectForm),       UIFromName.SelectForm,       FGUISelectForm.URL),
            [UIFromName.LoadGameForm]       = new UICfgItem(typeof(LoadGameForm),     UIFromName.LoadGameForm,     FGUILoadGame.URL),
            [UIFromName.BattleForm]         = new UICfgItem(typeof(BattleForm),       UIFromName.BattleForm,       FGUIBattleForm.URL),
            [UIFromName.ActionForm]         = new UICfgItem(typeof(ActionForm),       UIFromName.ActionForm,       FGUIActionForm.URL),
            [UIFromName.ReleaseSkillForm]   = new UICfgItem(typeof(ReleaseSkillForm), UIFromName.ReleaseSkillForm, FGUIActionForm.URL),
        };

        public static UICfgItem GetCfg(string name)
        {
            return cfg[name];
        }
    }

    public class UICfgItem
    {
        public Type FormType = default;
        public string FormName = "";
        public string FormURL = "";
        public string FormGroup = "Default";

        public UICfgItem(Type type, string name, string url, string group = "Default")
        {
            FormType = type;
            FormName = name;
            FormURL = url;
            FormGroup = group;
        }
    }

    public static class UIExtension
    {
        public static int OpenUIForm(this UIComponent uiComponent, string name, object data = default)
        {
            return uiComponent.OpenUIForm(name, "Default", data);
        }

        public static void CloseUIForm(this UIComponent uiComponent, string name)
        {
            var uiForms = uiComponent.GetUIForms(name);
            foreach(var form in uiForms)
            {
                if (form.UIFormAssetName == name)
                {
                    uiComponent.CloseUIForm(form);
                }
            }
        }
    }
}