using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using UnityEngine;
using LDtkUnity;

namespace HEDAO
{
    public class WorldGridUnitView : EntityView
    {
        private int m_FloatId = 0;
        
        private SpriteRenderer m_Renderer;
        
        public WorldMapView Parent => GameEntry.Entity.GetEntityLogic<WorldMapView>(Data.Parent.Id);
        public new WorldGridUnit Data { get; private set; }
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Renderer = GetComponent<SpriteRenderer>();
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Data = userData as WorldGridUnit;

            m_Renderer.sprite = Data.Template.Tile;
            transform.parent = Parent.transform;
            transform.position = Parent.GridPosToWorldPos(Data.GridPos);
            
            //m_FloatId = GameEntry.UI.OpenUIForm(UIFromName.FloatGridUnit, this);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.UI.CloseUIForm(m_FloatId);
            Data = null;
            
            base.OnHide(isShutdown, userData);
        }
    }
}