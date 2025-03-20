using System;
using System.Collections.Generic;
using FairyGUI;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HEDAO
{
    public class ProcedureLiLian : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(EventName.StartBattle, OnStartBattle);

            GameEntry.UI.OpenUIForm(UIName.LiLianForm, this);
        }

        private void OnStartBattle(object sender, GameEventArgs e)
        {
            var ne = e as GameEventBase;
            Owner.SetData<VarInt32>("BattleId", (int) ne.EventData);
            ChangeState<ProcedureBattle>(Owner);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }
        
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Save.SaveGame();

            GameEntry.UI.CloseAllLoadedUIForms();

            GameEntry.Event.Unsubscribe(EventName.StartBattle, OnStartBattle);

            base.OnLeave(procedureOwner, isShutdown);
        }

        public void StartLiLian(Vector2Int TargetPos)
        {
            
        }
    }
}
