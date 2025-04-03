using System;
using System.Collections.Generic;
using UnityEngine;

public class Fsm
{
    private readonly Dictionary<Type, FsmState> m_States = new Dictionary<Type, FsmState>();
    public FsmState CurState { get; private set; }

    protected Fsm()
    {
    }

    public static Fsm CreatFsm(params FsmState[] states)
    {
        var fsm = new Fsm();

        foreach (FsmState state in states)
        {
            Type stateType = state.GetType();
            if (fsm.m_States.ContainsKey(stateType))
            {
                continue;
            }

            fsm.m_States.Add(stateType, state);
            state.OnInit();
        }

        return fsm;
    }

    public void ChangeState<T>(object data = default)
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
        CurState.OnEnter(data);
    }

    public void OnUpdate()
    {
        CurState?.OnUpdate();
    }

    public void Start<T>()
        where T : FsmState
    {
        CurState = GetState(typeof(T));
        CurState.OnEnter(default);
    }
    
    public void Start(Type type)
    {
        CurState = GetState(type);
        CurState.OnEnter(default);
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
