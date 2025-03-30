using System;

public abstract class FsmState
{
    public FsmState()
    {
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnEnter(object data)
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual void OnLeave()
    {
    }

    protected virtual void OnDestroy()
    {
    }
}
