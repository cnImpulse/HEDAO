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
        UpdatePos();
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

    private void UpdatePos()
    {
        if (Data.FollowId > 0)
        {
            var entity = GameMgr.Entity.GetEntityView<EntityView>(Data.FollowId);
            if (entity != null)
            {
                Data.Position = entity.transform.position;
            }
        }
        transform.position = Data.Position;
    }
}
