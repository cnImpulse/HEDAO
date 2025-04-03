using UnityEngine;


public class EffectView : EntityView
{
    public EffectData Data => Entity as EffectData;

    private float m_RealLifeTime = 0;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_RealLifeTime = 0;
        transform.position = Data.Position;
    }

    private void Update()
    {
        transform.position = Data.Position;
        if (Data.LifeTime <= 0)
        {
            return;
        }

        m_RealLifeTime += Time.deltaTime;
        if (m_RealLifeTime >= Data.LifeTime)
        {
            Hide();
        }
    }
}
