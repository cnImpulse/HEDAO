using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using UnityEngine;
using LDtkUnity;

namespace HEDAO
{
    public class WorldGridUnit : Entity
    {
        private SpriteRenderer m_Renderer;
        
        public WorldMap Parent => GameEntry.Entity.GetEntityLogic<WorldMap>(Data.Parent.Id);
        public new WorldGridUnitData Data { get; private set; }
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Renderer = GetComponent<SpriteRenderer>();
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Data = userData as WorldGridUnitData;

            m_Renderer.sprite = Data.Template.Tile;
            transform.parent = Parent.transform;
            transform.position = Parent.GridPosToWorldPos(Data.GridPos);
        }
    }
}