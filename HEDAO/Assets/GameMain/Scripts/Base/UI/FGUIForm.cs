using FairyGUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class FGUIForm<T> : UIFormLogic
        where T : GComponent
    {
        private T m_View = default;
        public T View => m_View;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_View = GetComponent<UIPanel>()?.ui as T;
            if (m_View == null)
            {
                Log.Error("FGUI View is null!");
                return;
            }
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
        }

        public void Close()
        {
            GameEntry.UI.CloseUIForm(UIForm);
        }
    }
}