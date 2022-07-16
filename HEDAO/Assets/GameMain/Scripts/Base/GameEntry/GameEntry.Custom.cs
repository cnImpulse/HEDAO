using UnityEngine;
using GFGameEntry = UnityGameFramework.Runtime.GameEntry;

namespace HEDAO
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static CfgComponent Cfg { get; private set; }
        public static EffectComponent Effect { get; private set; }
        public static SaveComponent Save { get; private set; }

        private static void InitCustomComponents()
        {
            Cfg = GFGameEntry.GetComponent<CfgComponent>();
            Effect = GFGameEntry.GetComponent<EffectComponent>();
            Save = GFGameEntry.GetComponent<SaveComponent>();
        }
    }
}
