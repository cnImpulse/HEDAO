using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;

namespace HEDAO
{
    public abstract class ActionNodeBase
    {
        public int CfgId { get; private set; }
        public ActionCfg Cfg => GameEntry.Cfg.Tables.TbActionCfg.Get(CfgId);

        public ActionNodeBase(int cfgId)
        {
            CfgId = cfgId;
        }

        public void Action()
        {
            OnAction();
        }

        protected virtual void OnAction()
        {
        }
    }
}

