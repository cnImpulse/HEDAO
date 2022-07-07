using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class Effect : Entity
    {
        private EffectData m_Data = null;

        private float m_RealLifeTime = 0;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as EffectData;

            m_RealLifeTime = 0;
            transform.position = m_Data.Position;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            transform.position = m_Data.Position;
            if (m_Data.LifeTime <= 0)
            {
                return;
            }

            m_RealLifeTime += elapseSeconds;
            if (m_RealLifeTime >= m_Data.LifeTime)
            {
                Hide();
            }
        }
    }
}