﻿using System.Collections.Generic;
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

             GameEntry.UI.OpenUIForm(UIName.LiLianForm, this);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }
        
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Save.SaveGame();
            
            GameEntry.UI.CloseUIForm(UIName.LiLianForm);
            
            base.OnLeave(procedureOwner, isShutdown);
        }

        public void StartLiLian(Vector2Int TargetPos)
        {
            
        }
    }
}
