using FairyGUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class FGUIForm<T> : UIFormLogic
        where T : GComponent
    {
        private UIPanel m_UIPanel = default;
        private T m_View = default;
        public T View => m_View;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_UIPanel = GetComponent<UIPanel>();
            m_View = m_UIPanel.ui as T;
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

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            Log.Info("界面: {0}, uiGroupDepth: {1}, depthInUIGroup: {2}", UIForm.UIFormAssetName, uiGroupDepth, depthInUIGroup);

            m_UIPanel.SetSortingOrder(uiGroupDepth * 10 + depthInUIGroup, true);
        }
    }
}