using UnityEngine;


public class EffectView : EntityView
{
    private EffectData Data => Entity as EffectData;

    private float m_RealLifeTime = 0;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_RealLifeTime = 0;
        transform.position = Data.Position;
    }

    //protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    //{
    //    base.OnUpdate(elapseSeconds, realElapseSeconds);

    //    transform.position = m_Data.Position;
    //    if (m_Data.LifeTime <= 0)
    //    {
    //        return;
    //    }

    //    m_RealLifeTime += elapseSeconds;
    //    if (m_RealLifeTime >= m_Data.LifeTime)
    //    {
    //        Hide();
    //    }
    //}
}
