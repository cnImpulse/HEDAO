using System;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HEDAO
{
    public class ProcedureMain : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Log.Info("游戏开始。");

            GameEntry.Event.Subscribe(EventName.StartGame, OnStartGame);

            GameEntry.UI.OpenUIForm(UIFromName.MenuForm);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //if (m_StartGame)
            //{
            //    GameEntry.Save.SaveGame();
            //    ChangeState<ProcedureBattle>(procedureOwner);
            //}
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.UI.CloseUIForm(UIFromName.MenuForm);
            GameEntry.UI.CloseUIForm(UIFromName.MainForm);
            GameEntry.Event.Unsubscribe(EventName.StartGame, OnStartGame);

            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnStartGame(object sender, GameEventArgs e)
        {
            GameEntry.Save.SaveGame();
            GameEntry.UI.OpenUIForm(UIFromName.MainForm);
        }
    }
}
