using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using System;
using System.Collections.Generic;

namespace HEDAO
{
    public abstract class Entity : EntityLogic
    {
        private EntityData m_Data = null;
        public EntityData Data => m_Data;

        public int Id => Entity.Id;

        protected void InitLayer(string layerName)
        {
            var renderers = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; ++i)
            {
                renderers[i].sortingLayerID = SortingLayer.NameToID(layerName);
            }
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            InitLayer(Entity.EntityGroup.Name);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as EntityData;
            if (m_Data == null)
            {
                Log.Error("Entity data is invalid!");
                return;
            }
            
            Name = Utility.Text.Format("[{0}-{1}]", m_Data.Name, Id);
        }

        public void Hide()
        {
            GameEntry.Entity.HideEntity(Id);
        }
    }
}
