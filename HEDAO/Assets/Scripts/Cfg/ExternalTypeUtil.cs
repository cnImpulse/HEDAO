using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cfg
{
    public static class ExternalTypeUtil 
    {
        public static  HEDAO.Range NewRange(Cfg.Range v)
        {
            return new HEDAO.Range { Min = v.Min, Max = v.Max };
        }
    }
}