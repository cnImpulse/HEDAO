using System;

public abstract class FsmState
{
    public Fsm Fsm { get; private set; }
    public object Owner => Fsm.Owner;
    
    public virtual void Init(Fsm fsm)
    {
        Fsm = fsm;
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual void OnLeave()
    {
    }

    public virtual void OnCleanUp()
    {
    }
    
    public void ChangeState<T>()
        where T : FsmState
    {
        Fsm.ChangeState<T>();
    }
}
