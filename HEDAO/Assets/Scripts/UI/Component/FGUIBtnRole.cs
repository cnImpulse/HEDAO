using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBtnRole : GButton
    {
        public void Refresh(Role role)
        {
            var cfg = GameMgr.Cfg.Tables.TbLevelCfg.Get(role.Level);
            text = string.Format("{0}\n{1}", role.Name, cfg.Name);
        }
    }
}