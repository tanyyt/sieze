using System.Collections.Generic;

namespace Utils
{
    public class EventBus : IEventBus
    {
        private readonly List<IEventHandleable> m_EventHandles = new List<IEventHandleable>();
        private readonly object m_SyncObject = new object();

        public void Publish<T>(T notification) where T : INotification
        {
            lock (m_SyncObject)
            {
                foreach (var handler in m_EventHandles)
                {
                    ((IEventHandleable<T>) handler).Handle(notification);
                }
            }
        }

        public void Clear()
        {
            lock (m_SyncObject)
            {
                m_EventHandles.Clear();
            }
        }

        public void Unsubscribe<T>(IEventHandleable<T> eventHandle) where T : INotification
        {
            lock (m_SyncObject)
            {
                m_EventHandles.Remove(eventHandle);
            }
        }

        public void Subscribe<T>(IEventHandleable<T> eventHandle) where T : INotification
        {
            lock (m_SyncObject)
            {
                m_EventHandles.Add(eventHandle);
            }
        }
    }
}