using System;
using UnityEngine;
using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        private static int s_SerialId = 0;

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return ++s_SerialId;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void ShowBattleMap(this EntityComponent entityComponent, int mapId)
        {
            ShowGridMap<BattleMap>(entityComponent, mapId);
        }
        
        public static void ShowGridMap<T>(this EntityComponent entityComponent, int mapId)
            where T : GridMap
        {
            string path = AssetUtl.GetGridMapDataPath(mapId);
            GameEntry.Resource.LoadAsset(path, (assetName, asset, duration, userData) =>
            {
                TextAsset text = asset as TextAsset;
                BattleMapData data = Utility.Json.ToObject<BattleMapData>(text.text);
                entityComponent.ShowEntity<T>(data.Id, AssetUtl.GetGridMapPath(mapId), "GridMap", data);
            });
        }

        public static void ShowBattleUnit(this EntityComponent entityComponent, BattleUnitData data)
        {
            string path = AssetUtl.GetBattleUnitPath();
            entityComponent.ShowEntity<BattleUnit>(data.Id, path, "GridUnit", data);
        }
        
        public static void ShowGridUnit(this EntityComponent entityComponent, GridUnitData data)
        {
            string path = AssetUtl.GetGridUnitPath();
            entityComponent.ShowEntity<GridUnit>(data.Id, path, "GridUnit", data);
        }

        public static void ShowEffect<T>(this EntityComponent entityComponent, EffectData data)
            where T : Effect
        {
            entityComponent.ShowEntity<T>(data.Id, data.Path, "Effect", data);
        }

        public static void ShowEffect(this EntityComponent entityComponent, EffectData data)
        {
            entityComponent.ShowEffect<Effect>(data);
        }

        public static T GetEntityData<T>(this EntityComponent entityComponent, int entityId)
            where T : EntityData
        {
            return (entityComponent.GetEntity(entityId)?.Logic as Entity)?.Data as T;
        }

        public static T GetEntityLogic<T>(this EntityComponent entityComponent, int entityId)
            where T : EntityLogic
        {
            return entityComponent.GetEntity(entityId)?.Logic as T;
        }

        public static void ShowEntity<T>(this EntityComponent entityComponent, EntityData data, int cfgId)
            where T : EntityLogic
        {
            var cfg = GameEntry.Cfg.Tables.TbEntityCfg.Get(cfgId);
            entityComponent.ShowEntity<T>(data.Id, cfg.Path, cfg.Group, data);
        }
    }
}
