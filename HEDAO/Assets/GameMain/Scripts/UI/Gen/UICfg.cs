using System;
using System.Collections.Generic;
using FGUI.CommonUI;

namespace HEDAO
{
    public static partial class UICfg
    {
        static UICfg()
        {
            cfg[UIName.MenuForm] = new UICfgItem(typeof(MenuForm), FGUIMenuForm.URL);
            cfg[UIName.MenuActionSelect] = new UICfgItem(typeof(MenuActionSelect), FGUIMenuActionSelect.URL);
        }
    }
}
