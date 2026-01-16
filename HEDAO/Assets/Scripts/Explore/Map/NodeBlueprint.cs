using UnityEngine;
using UnityEngine.Serialization;

namespace Map
{
    public enum NodeType
    {
        MinorEnemy,
        EliteEnemy,
        RestSite,
        Treasure,
        Store,
        Boss,
        Mystery
    }
}

namespace Map
{
    [CreateAssetMenu]
    public class NodeBlueprint : ScriptableObject
    {
        public Sprite sprite;
        public NodeType nodeType;
        [FormerlySerializedAs("exporeId")] public int exploreId = 10001;
    }
}