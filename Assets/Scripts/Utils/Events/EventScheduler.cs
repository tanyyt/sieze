using System;
using System.Collections.Generic;

namespace Utils
{
    public class EventScheduler<TEventKey> : IEventScheduling<TEventKey>
    {
        private static readonly Lazy<EventScheduler<TEventKey>> s_Global = new Lazy<EventScheduler<TEventKey>>(() => new EventScheduler<TEventKey>());
        public static readonly EventScheduler<TEventKey> Global = s_Global.Value;
        private readonly Dictionary<TEventKey, IEventBus> m_EventMapping = new Dictionary<TEventKey, IEventBus>();

        public IEventBus this[TEventKey key]
        {
            get => m_EventMapping[key];
            set => m_EventMapping[key] = value;
        }

        public bool Contains(TEventKey eventKey) => m_EventMapping.ContainsKey(eventKey);
        public void Register(TEventKey eventKey, IEventBus eventBus) => m_EventMapping.Add(eventKey, eventBus);
        public void Unregister(TEventKey eventKey) => m_EventMapping.Remove(eventKey);
        public void Clear() => m_EventMapping.Clear();
    }
}