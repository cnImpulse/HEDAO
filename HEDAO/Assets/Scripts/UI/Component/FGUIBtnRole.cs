using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBtnRole : GButton
    {
        public void Refresh(Role role, bool enableRight = true)
        {
            var cfg = GameMgr.Cfg.TbLevelCfg.Get(role.Level);
            text = string.Format("{0}\n{1}", role.Name, cfg.Name);
            if (enableRight)
            {
                onRightClick.Set(() => OnRightClickRole(role));
            }
            else
            {
                onRightClick.Clear();
            }
        }

        private void OnRightClickRole(Role role)
        {
            GameMgr.UI.ShowUI(UIName.MenuRole, role);
        }
    }
}