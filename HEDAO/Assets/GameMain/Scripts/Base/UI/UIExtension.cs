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
        public const string MainForm = "MainForm";
        public const string DiscipleForm = "DiscipleForm";
        public const string BattleForm = "BattleForm";
        public const string ActionForm = "ActionForm";
        public const string ReleaseSkillForm = "ReleaseSkillForm";
        
        public const string CommonTips = "CommonTips";
        public const string BattleUnitInfo = "BattleUnitInfo";
        public const string BattleStateEffect = "BattleStateEffect";
    }

    public static class UICfg
    {
        private static Dictionary<string, UICfgItem> cfg = new Dictionary<string, UICfgItem>()
        {
            [UIFromName.MenuForm]           = new UICfgItem(typeof(MenuForm),           FGUIMenuForm.URL),
            [UIFromName.SelectForm]         = new UICfgItem(typeof(SelectForm),         FGUISelectForm.URL),
            [UIFromName.LoadGameForm]       = new UICfgItem(typeof(LoadGameForm),       FGUILoadGame.URL),
            [UIFromName.BattleForm]         = new UICfgItem(typeof(BattleForm),         FGUIBattleForm.URL),
            [UIFromName.ActionForm]         = new UICfgItem(typeof(ActionForm),         FGUIActionForm.URL),
            [UIFromName.ReleaseSkillForm]   = new UICfgItem(typeof(ReleaseSkillForm),   FGUIActionForm.URL),
            [UIFromName.CommonTips]         = new UICfgItem(typeof(CommonTips),         FGUICommonTips.URL),
            [UIFromName.BattleUnitInfo]     = new UICfgItem(typeof(BattleUnitInfo),     FGUIBattleUnitInfo.URL),
            [UIFromName.BattleStateEffect]  = new UICfgItem(typeof(BattleStateEffect),  FGUIBattleStateEffect.URL),
            [UIFromName.MainForm]           = new UICfgItem(typeof(MainForm),           FGUIMainForm.URL),
            [UIFromName.DiscipleForm]       = new UICfgItem(typeof(DiscipleForm),       FGUIDiscipleForm.URL),
        };

        public static UICfgItem GetCfg(string name)
        {
            return cfg[name];
        }
    }

    public class UICfgItem
    {
        public Type FormType = default;
        public string FormURL = "";
        public string FormGroup = "Default";

        public UICfgItem(Type type, string url, string group = "Default")
        {
            FormType = type;
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