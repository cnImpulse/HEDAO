using FairyGUI;
using UnityEngine;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HEDAO
{
    public class ProcedureBattle : ProcedureBase
    {
        private IFsm<ProcedureBattle> m_Fsm = null;

        private BattleRunTimeData m_BattleInfo = null;
        public BattleRunTimeData BattleData => m_BattleInfo;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            var id = procedureOwner.GetData<VarInt32>("BattleId");
            InitBattle(id);
            
            GameEntry.Event.Subscribe(EventName.BattleEnd, OnBattleEnd);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(EventName.BattleEnd, OnBattleEnd);
            
            GameEntry.Fsm.DestroyFsm(m_Fsm);
            m_BattleInfo = null;

            base.OnLeave(procedureOwner, isShutdown);
        }

        private void InitBattle(int levelId)
        {
            LoadLevelData(levelId);
        }

        private void LoadLevelData(int levelId)
        {
            string path = AssetUtl.GetLevelDataPath(levelId);
            GameEntry.Resource.LoadAsset(path, (assetName, asset, duration, userData) =>
            {
                TextAsset textAsset = asset as TextAsset;
                var data = Utility.Json.ToObject<LevelData>(textAsset.text);
                InitBattleRunTimeData(data);
                InitBattleFsm();
            });
        }

        public void InitBattleRunTimeData(LevelData data)
        {
            m_BattleInfo = new BattleRunTimeData(data);
        }

        private void InitBattleFsm()
        {
            m_Fsm = GameEntry.Fsm.CreateFsm(this, new BattleStartState(), new RoundStartState(),
                new BattleUnitSelectState(), new BattleState(), new RoundEndState(), new BattleEndState());
            m_Fsm.Start<BattleStartState>();
        }
        
        private void OnBattleEnd(object sender, GameEventArgs e)
        {
            var ne = (GameEventBase)e;
            var failCampType = (CampType)ne.EventData;
            (m_Fsm.CurrentState as BattleStateBase).ChangeState<BattleEndState>();
            
        }
    }
}
