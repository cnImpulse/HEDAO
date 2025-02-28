using System;
using System.Collections.Generic;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static partial class UIName
    {
        public const string SelectForm = "SelectForm";
        public const string LoadGameForm = "LoadGame";
        public const string MainForm = "MainForm";
        public const string DiscipleForm = "DiscipleForm";
        public const string PrepareForm = "PrepareForm";
        public const string BattleForm = "BattleForm";
        public const string ActionForm = "ActionForm";
        public const string ReleaseSkillForm = "ReleaseSkillForm";
        public const string LiLianForm = "LiLianForm";
        
        public const string CommonTips = "CommonTips";
        public const string BattleUnitInfo = "BattleUnitInfo";
        public const string BattleStateEffect = "BattleStateEffect";
        public const string FloatGridUnit = "FloatGridUnit";
    }
    
    public static partial class UICfg
    {
        private static Dictionary<string, UICfgItem> cfg = new Dictionary<string, UICfgItem>()
        {
            [UIName.SelectForm]         = new UICfgItem(typeof(SelectForm),         FGUISelectForm.URL),
            [UIName.LoadGameForm]       = new UICfgItem(typeof(LoadGameForm),       FGUILoadGame.URL),
            [UIName.BattleForm]         = new UICfgItem(typeof(BattleForm),         FGUIBattleForm.URL),
            [UIName.ActionForm]         = new UICfgItem(typeof(ActionForm),         FGUIActionForm.URL),
            [UIName.ReleaseSkillForm]   = new UICfgItem(typeof(ReleaseSkillForm),   FGUIActionForm.URL),
            [UIName.MainForm]           = new UICfgItem(typeof(MainForm),           FGUIMainForm.URL),
            [UIName.DiscipleForm]       = new UICfgItem(typeof(DiscipleForm),       FGUIDiscipleForm.URL),
            [UIName.PrepareForm]        = new UICfgItem(typeof(PrepareForm),        FGUIPrepareForm.URL),
            [UIName.LiLianForm]         = new UICfgItem(typeof(LiLianForm),         FGUILiLianForm.URL),
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