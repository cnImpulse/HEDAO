using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    /// <summary>
    /// 战斗单位。
    /// </summary>
    public partial class BattleUnit : GridUnit
    {
        private int m_BattleUnitInfoId = 0;

        private BattleUnitData m_Data = null;
        public new BattleUnitData Data => m_Data;

        private void InitSprite()
        {
            string path = AssetUtl.GetTilePath("BattleUnit", Data.RoleData.Image);
            if (GameEntry.Resource.HasAsset(path) == HasAssetResult.NotExist)
            {
                return;
            }

            InternalSetVisible(false);
            GameEntry.Resource.LoadAsset(path, 
            (assetName, asset, duration, userData) =>
            {
                var tile = asset as Tile;
                m_SpriteRenderer.sprite = tile.sprite;
                InternalSetVisible(true);
            });
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as BattleUnitData;

            InitSprite();
            m_BattleUnitInfoId = GameEntry.UI.OpenUIForm(UIName.BattleUnitInfo, this);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.UI.CloseUIForm(m_BattleUnitInfoId);
            m_Data = null;

            base.OnHide(isShutdown, userData);
        }
    }
}
