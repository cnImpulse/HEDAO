using System;
using System.Collections.Generic;
using UnityEngine;

public class Fsm
{
    private readonly Dictionary<Type, FsmState> m_States;
    private FsmState m_CurState;

    protected Fsm()
    {
        m_States = new Dictionary<Type, FsmState>();
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

        if (m_CurState == state)
        {
            return;
        }

        m_CurState.OnLeave();
        m_CurState = state;
        m_CurState.OnEnter(data);
    }

    public void Start(Type stateType)
    {
        m_CurState = GetState(stateType); ;
        m_CurState.OnEnter(default);
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
