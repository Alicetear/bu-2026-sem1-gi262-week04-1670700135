using UnityEngine;

namespace Assignment
{
    [System.Serializable]
    public class GameEvent
    {
        public string eventType;
        public string eventName;
        public int priority = 1;

        public string EventType => eventType;
        public string Name => eventName;
        public int Priority => priority;

        public GameEvent(string eventType, string description, int priority = 1)
        {
            this.eventType = eventType;
            eventName = description;
            this.priority = priority;
        }
    }
}
