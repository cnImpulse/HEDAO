using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    None,
    OnPointerDownMap,
    OnPlayerRoundStart,
    OnTakeBattleEffect,
}

public class GameEvent
{
    public GameEventType GameEventType { get; private set; }
    public object Data { get; private set; }

    public static GameEvent Create(GameEventType type, object data)
    {
        var e = new GameEvent();
        e.GameEventType = type;
        e.Data = data;
        return e;
    }
}

public class EventManager : BaseManager
{
    private Dictionary<GameEventType, Delegate> m_EventHandlers = new Dictionary<GameEventType, Delegate>();

    public void Subscribe(GameEventType eventType, Action<GameEvent> handler)
    {
        if (m_EventHandlers.TryGetValue(eventType, out Delegate handlers))
        {
            m_EventHandlers[eventType] = Delegate.Combine(handlers, handler);
        }
        else
        {
            m_EventHandlers[eventType] = handler;
        }
    }

    public void Unsubscribe(GameEventType eventType, Action<GameEvent> handler)
    {
        if (m_EventHandlers.TryGetValue(eventType, out Delegate handlers))
        {
            m_EventHandlers[eventType] = Delegate.Remove(handlers, handler);
        }
    }

    public void Fire(GameEventType type, object data = default)
    {
        var e = GameEvent.Create(type, data);
        if (m_EventHandlers.TryGetValue(type, out Delegate handlers))
        {
            (handlers as Action<GameEvent>)?.Invoke(e);
        }
    }
}