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
        private HPBar m_HPBar = null;
        private SpriteRenderer m_SpriteRenderer = null;

        private BattleUnitData m_Data = null;
        public new BattleUnitData Data => m_Data;

        private void InitSprite()
        {
            m_SpriteRenderer.color = BattleUtl.GetCampColor(Data.CampType);
            string path = AssetUtl.GetTilePath("BattleUnit", Data.RoleData.Image);
            if (GameEntry.Resource.HasAsset(path) == HasAssetResult.NotExist)
            {
                return;
            }

            InternalSetVisible(false);
            GameEntry.Resource.LoadAsset(path, 
            (assetName, asset, duration, userData) =>
            {
                var tile = asset as RuleTile;
                m_SpriteRenderer.sprite = tile.m_DefaultSprite;
                InternalSetVisible(true);
            });
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as BattleUnitData;

            InitSprite();
            m_HPBar = HPBar.CreateInstance(this);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            m_Data = null;
            m_HPBar.Release();

            base.OnHide(isShutdown, userData);
        }
    }
}
