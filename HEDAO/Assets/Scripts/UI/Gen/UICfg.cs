using System;
using System.Collections.Generic;
using FGUI.Common;

public static partial class UICfg
{
    static UICfg()
    {
        cfg[UIName.MenuMain] = new UICfgItem(typeof(MenuMain), FGUIMenuMain.URL);
        cfg[UIName.MenuActionSelect] = new UICfgItem(typeof(MenuActionSelect), FGUIMenuActionSelect.URL);
    }
}
