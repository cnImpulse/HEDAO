using UnityEngine;

namespace HEDAO
{
    public class EffectData : EntityData
    {
        public EffectData(string name, Vector3 position, float lifetime)
        {
            Name = name;
            Position = position;
            LifeTime = lifetime;
            Path = AssetUtl.GetEffectPath(name);
        }

        public Vector3 Position { get; set; }

        public float LifeTime { get; protected set; }

        public string Path { get; protected set; }
    }
}