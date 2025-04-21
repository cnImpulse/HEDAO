using System.Collections;
using System.Collections.Generic;
using Cfg;
using Cfg.Battle;

public enum BattleUnitActionType
{
    None,
    [EnumName("术法")]
    Skill,
    [EnumName("遁术")]
    Move,
    [EnumName("调息")]
    Wait,
}

public enum EBattleResult
{
    None,
    Win,
    Lose,
}

public class ReqBattleUnitAction
{
    public GridUnit Caster;
    public List<ReqActionBase> ReqActionList = new List<ReqActionBase>();
}

public class ReqWait : ReqActionBase
{
}

public abstract class ReqActionBase
{
}

public class ReqMove : ReqActionBase
{
    public GridData End;
}

public class ReqSkill : ReqActionBase
{
    public int SkillId;
    public GridData Target;
}     

public abstract class RspActionBase
{
    public GridUnit Caster;
}

public abstract class BattleEvent
{

}

public class BattleEndEvent : BattleEvent
{
    public EBattleResult Result;
}

public class BattleUnitActionEvent : BattleEvent
{
    public long BattleUnitId;
    public List<RspActionBase> ActionList = new List<RspActionBase>();
    public List<long> DeadList = new List<long>();
}

public class WaitEvent : RspActionBase
{
}

public class MoveEvent : RspActionBase
{
    public List<GridData> MovePath;
}

public class SkillEvent : RspActionBase
{
    public GridUnit Target;
    public int SkillId;
    public bool IsMiss = false;
    public List<TakeEffectResult> Results;
}