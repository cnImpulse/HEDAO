using System;
using System.Collections.Generic;
using UnityEngine;

public class Fsm
{
    private readonly Dictionary<Type, FsmState> m_States = new Dictionary<Type, FsmState>();
    public FsmState CurState { get; private set; }
    public object Owner { get; private set; }

    protected Fsm(object owner)
    {
        Owner = owner;
    }

    public static Fsm CreatFsm(object owner, params FsmState[] states)
    {
        var fsm = new Fsm(owner);
        foreach (FsmState state in states)
        {
            Type stateType = state.GetType();
            if (fsm.m_States.ContainsKey(stateType))
            {
                continue;
            }

            fsm.m_States.Add(stateType, state);
            state.Init(fsm);
        }

        return fsm;
    }

    public static void DestroyFsm(Fsm fsm)
    {
        fsm.CurState.OnLeave();
        foreach (FsmState state in fsm.m_States.Values)
        {
            state.OnDestroy();
        }
    }

    public void ChangeState<T>()
        where T : FsmState
    {
        if (!m_States.TryGetValue(typeof(T), out var state))
        {
            return;
        }

        if (CurState == state)
        {
            return;
        }

        CurState.OnLeave();
        CurState = state;
        CurState.OnEnter();
    }

    public void OnUpdate()
    {
        CurState?.OnUpdate();
    }

    public void Start<T>()
        where T : FsmState
    {
        CurState = GetState(typeof(T));
        CurState.OnEnter();
    }
    
    public void Start(Type type)
    {
        CurState = GetState(type);
        CurState.OnEnter();
    }

    public FsmState GetState(Type type)
    {
        FsmState state = null;
        if (m_States.TryGetValue(type, out state))
        {
            return state;
        }

        return null;
    }
}
