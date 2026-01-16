using System;
using System.Collections.Generic;
using FGUI.Common;

public static partial class UICfg
{
    static UICfg()
    {
        cfg[UIName.MenuBattleEnd] = new UICfgItem(typeof(MenuBattleEnd), FGUIMenuBattleEnd.URL);
        cfg[UIName.MenuMain] = new UICfgItem(typeof(MenuMain), FGUIMenuMain.URL);
        cfg[UIName.MenuDialog] = new UICfgItem(typeof(MenuDialog), FGUIMenuDialog.URL);
        cfg[UIName.WinLoadGame] = new UICfgItem(typeof(WinLoadGame), FGUIWinLoadGame.URL);
        cfg[UIName.FloatItemTips] = new UICfgItem(typeof(FloatItemTips), FGUIFloatItemTips.URL);
        cfg[UIName.FloatBubble] = new UICfgItem(typeof(FloatBubble), FGUIFloatBubble.URL);
        cfg[UIName.MenuHome] = new UICfgItem(typeof(MenuHome), FGUIMenuHome.URL);
        cfg[UIName.MenuActionSelect] = new UICfgItem(typeof(MenuActionSelect), FGUIMenuActionSelect.URL);
        cfg[UIName.FloatBattleUnit] = new UICfgItem(typeof(FloatBattleUnit), FGUIFloatBattleUnit.URL);
        cfg[UIName.MenuRole] = new UICfgItem(typeof(MenuRole), FGUIMenuRole.URL);
        cfg[UIName.FloatTips] = new UICfgItem(typeof(FloatTips), FGUIFloatTips.URL);
        cfg[UIName.MenuExplore] = new UICfgItem(typeof(MenuExplore), FGUIMenuExplore.URL);
        cfg[UIName.HudBattle] = new UICfgItem(typeof(HudBattle), FGUIHudBattle.URL);
    }
}
