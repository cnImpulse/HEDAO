using UnityEngine;

public class EffectData : Entity
{
    public Vector3 Position { get; set; }

    public float LifeTime { get; protected set; }
    public int PrefabId { get; protected set; }

    public EffectData(int prefabId, Vector3 position, float lifetime)
    {
        PrefabId = prefabId;
        Position = position;
        LifeTime = lifetime;
    }

    public override int GetPrefabId()
    {
        return PrefabId;
    }
}
