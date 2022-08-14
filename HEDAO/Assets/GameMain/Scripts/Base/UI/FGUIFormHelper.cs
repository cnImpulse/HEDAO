using GameFramework.UI;
using UnityEngine;
using FairyGUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    /// <summary>
    /// 默认界面辅助器。
    /// </summary>
    public class FGUIFormHelper : UIFormHelperBase
    {
        private ResourceComponent m_ResourceComponent = null;

        /// <summary>
        /// 创建界面。
        /// </summary>
        /// <param name="uiFormInstance">界面实例。</param>
        /// <param name="uiGroup">界面所属的界面组。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面。</returns>
        public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
        {
            GameObject gameObject = uiFormInstance as GameObject;
            if (gameObject == null)
            {
                Log.Error("UI form instance is invalid.");
                return null;
            }

            Transform transform = gameObject.transform;
            transform.SetParent(((MonoBehaviour)uiGroup.Helper).transform);

            return gameObject.GetOrAddComponent<UIForm>();
        }

        /// <summary>
        /// 释放界面。
        /// </summary>
        /// <param name="uiFormAsset">要释放的界面资源。</param>
        /// <param name="uiFormInstance">要释放的界面实例。</param>
        public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
        {
            Destroy((Object)uiFormInstance);
        }

        public override void InstantiateUIFormAsync(string uiFormName, object userData, CreatFormSuccessCallback callback)
        {
            //var startTime = Time.realtimeSinceStartup;

            var uiCfg = UICfg.GetCfg(uiFormName);
            GameObject go = new GameObject(uiFormName);
            go.layer = LayerMask.NameToLayer("UI");
            var panel = go.GetOrAddComponent<UIPanel>();
            panel.CreateUI(uiCfg.FormURL);
            go.GetOrAddComponent(uiCfg.FormType);
            callback(uiFormName, go, 0f, userData);

            //var form = go.GetOrAddComponent(uiCfg.FormType) as FGUIFormBase;
            //UIPackage.CreateObjectFromURL(uiCfg.FormURL, (view) => {
            //    form.InitView(view);
            //    GRoot.inst.AddChild(view);
            //    callback(uiFormName, go, Time.realtimeSinceStartup - startTime, userData);
            //});
        }

        public override object InstantiateUIForm(object uiFormAsset)
        {
            throw new System.NotImplementedException();
        }
    }
}
