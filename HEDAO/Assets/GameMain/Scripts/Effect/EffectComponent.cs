using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine.Tilemaps;
using Cfg.Effect;

namespace HEDAO
{
    public class EffectComponent : GameFrameworkComponent
    {
        [SerializeField]
        private Transform m_EffectInstanceRoot = null;

        private void Start()
        {
            if (m_EffectInstanceRoot == null)
            {
                Log.Error("You must set effect instance root first.");
                return;
            }

            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEffect);
        }

        public int ShowEffect(string name, Vector3 position = default, bool isSingleton = false, float lifetime = -1)
        {
            EffectData effectData = new EffectData(name, position, lifetime);
            if (isSingleton)
            {
                HideEffect(name);
            }
            
            GameEntry.Entity.ShowEffect(effectData);
            return effectData.Id;
        }

        public int ShowGridEffect(string name, List<Vector2Int> gridPosList, Vector3 position = default, float lifetime = -1)
        {
            GridEffectData effectData = new GridEffectData(gridPosList, name, position, lifetime);
            GameEntry.Entity.ShowEffect<GridEffect>(effectData);
            return effectData.Id;
        }

        public void HideEffect(string name)
        {
            var path = AssetUtl.GetEffectPath(name);
            var effects = GameEntry.Entity.GetEntities(path);
            foreach (var effect in effects)
            {
                GameEntry.Entity.HideEntity(effect);
            }
        }

        public void HideGridEffect()
        {
            HideEffect("GridEffect");
        }

        private void OnShowEffect(object sender, GameFrameworkEventArgs e)
        {
            var ne = (ShowEntitySuccessEventArgs)e;
            if (ne.Entity.Logic is Effect)
            {
                ne.Entity.transform.SetParent(m_EffectInstanceRoot);
            }
        }
    }
}