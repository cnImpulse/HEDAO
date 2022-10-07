using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class CmdMgr : Singleton<CmdMgr>
    {
        private Dictionary<int, Stack<Command>> m_CmdRecard = new Dictionary<int, Stack<Command>>();
    }
}
