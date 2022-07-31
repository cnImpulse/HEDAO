using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    public class GridEffect : Effect
    {
        private GridEffectData m_Data = null;

        private Tilemap m_Tilemap = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Tilemap = GetComponent<Tilemap>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as GridEffectData;

            m_Tilemap.color = m_Data.Color;
            m_Tilemap.ClearAllTiles();
            string tilePath = AssetUtl.GetTilePath("Effect", m_Data.GridEffectName);
            GameEntry.Resource.LoadAsset(tilePath,
            (assetName, asset, duration, userData) =>
            {
                var tile = asset as TileBase;
                foreach(var pos in m_Data.GridPosList)
                {
                    m_Tilemap.SetTile((Vector3Int)pos, tile);
                }
            });
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}