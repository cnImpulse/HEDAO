using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBtnRole : GButton
    {
        public LongPressGesture LongPress;

        public void Refresh(Role role, bool enableRight = true)
        {
            if (LongPress == null)
            {
                LongPress = new LongPressGesture(this);
                LongPress.once = true;
                LongPress.trigger = 1f;
            }

            var cfg = GameMgr.Cfg.TbLevelCfg.Get(role.Level);
            text = string.Format("{0}\n{1}", role.Name, cfg.Name);
            if (enableRight)
            {
                LongPress.onAction.Set(() => OnRightClickRole(role));
            }
            else
            {
                LongPress.onAction.Clear();
            }
        }

        private void OnRightClickRole(Role role)
        {
            GameMgr.UI.ShowUI(UIName.MenuRole, role);
        }
    }
}