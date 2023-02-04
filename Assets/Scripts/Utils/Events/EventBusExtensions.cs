using System;

namespace Utils
{
    public static class EventBusExtensions
    {
        #region Register

        public static void Register<TEventKey>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action action) 
            => scheduling.Register(eventKey, new ActionEventBus(action));
        public static void Register<TEventKey, T>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T>(action));
        public static void Register<TEventKey, T1, T2>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T1, T2>(action));
        public static void Register<TEventKey, T1, T2, T3>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T1, T2, T3>(action));
        public static void Register<TEventKey, T1, T2, T3, T4>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T1, T2, T3, T4>(action));
        public static void Register<TEventKey, T1, T2, T3, T4, T5>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4, T5> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T1, T2, T3, T4, T5>(action));
        public static void Register<TEventKey, T1, T2, T3, T4, T5, T6>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4, T5, T6> action) 
            => scheduling.Register(eventKey, new ActionEventBus<T1, T2, T3, T4, T5, T6>(action));

        #endregion

        #region Subscibe

        public static void Subscribe(this IEventSubscribable subscriber, Action action) 
            => subscriber.Subscribe(MethodEventWrapperPool.Instance.Require(action));
        public static void Subscribe<T>(this IEventSubscribable subscriber, Action<T> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T>.Instance.Require(action));
        public static void Subscribe<T1, T2>(this IEventSubscribable subscriber, Action<T1, T2> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T1, T2>.Instance.Require(action));
        public static void Subscribe<T1, T2, T3>(this IEventSubscribable subscriber, Action<T1, T2, T3> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T1, T2, T3>.Instance.Require(action));
        public static void Subscribe<T1, T2, T3, T4>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T1, T2, T3, T4>.Instance.Require(action));
        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4, T5> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T1, T2, T3, T4, T5>.Instance.Require(action));
        public static void Subscribe<T1, T2, T3, T4, T5, T6>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4, T5, T6> action) 
            => subscriber.Subscribe(MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>.Instance.Require(action));

        #endregion

        #region Unsubscribe

        public static void Unsubscribe(this IEventSubscribable subscriber, Action action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool.Instance.Require(action));
        public static void Unsubscribe<T>(this IEventSubscribable subscriber, Action<T> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T>.Instance.Require(action));
        public static void Unsubscribe<T1, T2>(this IEventSubscribable subscriber, Action<T1, T2> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T1, T2>.Instance.Require(action));
        public static void Unsubscribe<T1, T2, T3>(this IEventSubscribable subscriber, Action<T1, T2, T3> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T1, T2, T3>.Instance.Require(action));
        public static void Unsubscribe<T1, T2, T3, T4>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T1, T2, T3, T4>.Instance.Require(action));
        public static void Unsubscribe<T1, T2, T3, T4, T5>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4, T5> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T1, T2, T3, T4, T5>.Instance.Require(action));
        public static void Unsubscribe<T1, T2, T3, T4, T5, T6>(this IEventSubscribable subscriber, Action<T1, T2, T3, T4, T5, T6> action) 
            => subscriber.Unsubscribe(MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>.Instance.Require(action));

        #endregion

        #region Broadcast

        public static void Broadcast(this IEventPublishable publisher) 
            => publisher.Publish(EmptyNotification.Default);
        public static void Broadcast<T>(this IEventPublishable publisher, T parameter) 
            => publisher.Publish(EventArgumentPool<T>.Instance.Require(parameter));
        public static void Broadcast<T1, T2>(this IEventPublishable publisher, T1 parameter1, T2 parameter2) => publisher.Publish(EventArgumentPool<T1, T2>.Instance.Require(parameter1, parameter2));
        public static void Broadcast<T1, T2, T3>(this IEventPublishable publisher, T1 parameter1, T2 parameter2, T3 parameter3) 
            => publisher.Publish(EventArgumentPool<T1, T2, T3>.Instance.Require(parameter1, parameter2, parameter3));
        public static void Broadcast<T1, T2, T3, T4>(this IEventPublishable publisher, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4) 
            => publisher.Publish(EventArgumentPool<T1, T2, T3, T4>.Instance.Require(parameter1, parameter2, parameter3, parameter4));
        public static void Broadcast<T1, T2, T3, T4, T5>(this IEventPublishable publisher, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5) 
            => publisher.Publish(EventArgumentPool<T1, T2, T3, T4, T5>.Instance.Require(parameter1, parameter2, parameter3, parameter4, parameter5));

        public static void Broadcast<T1, T2, T3, T4, T5, T6>(this IEventPublishable publisher, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6) =>
            publisher.Publish(EventArgumentPool<T1, T2, T3, T4, T5, T6>.Instance.Require(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));

        #endregion

        #region RegisterOrSubscribe

        public static void RegisterOrSubscribe<TEventKey>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T1, T2>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T1, T2, T3>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T1, T2, T3, T4>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T1, T2, T3, T4, T5>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4, T5> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }

        public static void RegisterOrSubscribe<TEventKey, T1, T2, T3, T4, T5, T6>(this IEventScheduling<TEventKey> scheduling, TEventKey eventKey, Action<T1, T2, T3, T4, T5, T6> action)
        {
            if (scheduling.Contains(eventKey))
                scheduling[eventKey].Subscribe(action);
            else
                scheduling.Register(eventKey, action);
        }
        #endregion
    }
}