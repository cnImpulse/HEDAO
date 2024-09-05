using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using UnityEngine;
using LDtkUnity;

namespace HEDAO
{
    public class WorldMap : Entity
    {
        protected List<LDtkComponentEntity> EntityList;
        public new WorldMapData Data { get; private set; }
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            InitEntityList();
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Data = userData as WorldMapData;
        }

        private void InitEntityList()
        {
            EntityList.Clear();
            var project = GetComponent<LDtkComponentProject>();
            foreach (var world in project.Worlds)
            {
                foreach (var level in world.Levels)
                {
                    foreach (var layer in level.LayerInstances)
                    {
                        foreach (var entity in layer.EntityInstances)
                        {
                            EntityList.Add(entity);
                        }
                    }
                }
            }
        }

        private void ShowAllEntity()
        {
            foreach (var entity in EntityList)
            {
                // GameEntry.Entity.ShowEntity<GridUnit>();
            }
        }
    }
}