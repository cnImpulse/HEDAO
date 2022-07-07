using GameFramework;
using GameFramework.Event;

namespace HEDAO
{
    public class GameEventBase : GameEventArgs
    {
        private int m_Id = 0;

        public override int Id => m_Id;
        public string EventName { get; private set; }
        public object EventData { get; private set; }

        public static GameEventBase Create(string eventName, object eventData = default)
        {
            GameEventBase gameEvent = ReferencePool.Acquire<GameEventBase>();
            gameEvent.m_Id = eventName.GetHashCode();
            gameEvent.EventName = eventName;
            gameEvent.EventData = eventData;

            return gameEvent;
        }

        public override void Clear()
        {
            m_Id = 0;
            EventName = null;
            EventData = null;
        }
    }
}