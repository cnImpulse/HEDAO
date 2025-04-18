using UnityEngine;

public class EffectData : Entity
{
    public int PrefabId;
    public long FollowId = 0;
    public float LifeTime = -1;
    public Vector3 Position;


    public EffectData()
    {

    }

    public override int GetPrefabId()
    {
        return PrefabId;
    }
}
