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
        private bool m_StartAdventure = false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Log.Info("游戏开始。");

            GameEntry.Event.Subscribe(EventName.StartGame, OnStartGame);
            GameEntry.Event.Subscribe(EventName.StartAdventure, OnStartAdventure);

            GameEntry.UI.OpenUIForm(UIName.MenuForm);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_StartAdventure)
            {
                GameEntry.Save.SaveGame();
                ChangeState<ProcedureLiLian>(procedureOwner);
            }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Save.SaveGame();
            
            m_StartAdventure = false;
            GameEntry.UI.CloseUIForm(UIName.MenuForm);
            GameEntry.UI.CloseUIForm(UIName.MainForm);
            GameEntry.Event.Unsubscribe(EventName.StartGame, OnStartGame);
            GameEntry.Event.Unsubscribe(EventName.StartAdventure, OnStartAdventure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        private void OnStartGame(object sender, GameEventArgs e)
        {
            GameEntry.Save.SaveGame();
            GameEntry.UI.OpenUIForm(UIName.MainForm);
        }

        private void OnStartAdventure(object sender, GameEventArgs e)
        {
            m_StartAdventure = true;
        }
    }
}
