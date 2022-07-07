using UnityEngine;

namespace HEDAO
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static CfgComponent Cfg
        {
            get;
            private set;
        }

        public static EffectComponent Effect
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            Cfg = UnityGameFramework.Runtime.GameEntry.GetComponent<CfgComponent>();
            Effect = UnityGameFramework.Runtime.GameEntry.GetComponent<EffectComponent>();
        }
    }
}
