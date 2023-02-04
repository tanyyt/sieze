using System;

namespace Utils
{
    public class ActionEventBus : IEventBus
    {
        private Action m_ActionEvent;

        public ActionEventBus(Action actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus(Action action) => new ActionEventBus(action);

        public void Subscribe<T>(IEventHandleable<T> eventHandle) where T : INotification
        {
            if (!(eventHandle is MethodEventWrapper trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool.Instance.Recycle(trigger);
        }

        public void Unsubscribe<T>(IEventHandleable<T> eventHandle) where T : INotification
        {
            if (!(eventHandle is MethodEventWrapper trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool.Instance.Recycle(trigger);
        }

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action trigger) => m_ActionEvent += trigger;
        public void Unsubscribe(Action trigger) => m_ActionEvent -= trigger;

        public void Publish<T>(T notification) where T : INotification
        {
            m_ActionEvent.Invoke();
        }
    }

    public class ActionEventBus<T> : IEventBus
    {
        private Action<T> m_ActionEvent;

        public ActionEventBus(Action<T> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T>(Action<T> action) => new ActionEventBus<T>(action);

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T> trigger) => m_ActionEvent += trigger;
        public void Unsubscribe(Action<T> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T>)} type");
            m_ActionEvent.Invoke(parameters.Parameter);
            EventArgumentPool<T>.Instance.Recycle(parameters);
        }
    }

    public class ActionEventBus<T1, T2> : IEventBus
    {
        private Action<T1, T2> m_ActionEvent;

        public ActionEventBus(Action<T1, T2> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T1, T2>(Action<T1, T2> action) => new ActionEventBus<T1, T2>(action);

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T1, T2> trigger) => m_ActionEvent += trigger;

        public void Unsubscribe(Action<T1, T2> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T1, T2> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T1, T2>)} type");
            m_ActionEvent.Invoke(parameters.Parameter1, parameters.Parameter2);
            EventArgumentPool<T1, T2>.Instance.Recycle(parameters);
        }
    }

    public class ActionEventBus<T1, T2, T3> : IEventBus
    {
        private Action<T1, T2, T3> m_ActionEvent;

        public ActionEventBus(Action<T1, T2, T3> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T1, T2, T3>(Action<T1, T2, T3> action) => new ActionEventBus<T1, T2, T3>(action);
        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T1, T2, T3> trigger) => m_ActionEvent += trigger;

        public void Unsubscribe(Action<T1, T2, T3> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T1, T2, T3> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T1, T2, T3>)} type");
            m_ActionEvent.Invoke(parameters.Parameter1, parameters.Parameter2, parameters.Parameter3);
            EventArgumentPool<T1, T2, T3>.Instance.Recycle(parameters);
        }
    }

    public class ActionEventBus<T1, T2, T3, T4> : IEventBus
    {
        private Action<T1, T2, T3, T4> m_ActionEvent;

        public ActionEventBus(Action<T1, T2, T3, T4> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action) => new ActionEventBus<T1, T2, T3, T4>(action);

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T1, T2, T3, T4> trigger) => m_ActionEvent += trigger;

        public void Unsubscribe(Action<T1, T2, T3, T4> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T1, T2, T3, T4> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T1, T2, T3, T4>)} type");
            m_ActionEvent.Invoke(parameters.Parameter1, parameters.Parameter2, parameters.Parameter3, parameters.Parameter4);
            EventArgumentPool<T1, T2, T3, T4>.Instance.Recycle(parameters);
        }
    }

    public class ActionEventBus<T1, T2, T3, T4, T5> : IEventBus
    {
        private Action<T1, T2, T3, T4, T5> m_ActionEvent;

        public ActionEventBus(Action<T1, T2, T3, T4, T5> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action) => new ActionEventBus<T1, T2, T3, T4, T5>(action);

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T1, T2, T3, T4, T5> trigger) => m_ActionEvent += trigger;

        public void Unsubscribe(Action<T1, T2, T3, T4, T5> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4, T5> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4, T5>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4, T5>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4, T5> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4, T5>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4, T5>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T1, T2, T3, T4, T5> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T1, T2, T3, T4, T5>)} type");
            m_ActionEvent.Invoke(parameters.Parameter1, parameters.Parameter2, parameters.Parameter3, parameters.Parameter4, parameters.Parameter5);
            EventArgumentPool<T1, T2, T3, T4, T5>.Instance.Recycle(parameters);
        }
    }

    public class ActionEventBus<T1, T2, T3, T4, T5, T6> : IEventBus
    {
        private Action<T1, T2, T3, T4, T5, T6> m_ActionEvent;

        public ActionEventBus(Action<T1, T2, T3, T4, T5, T6> actionEvent) => m_ActionEvent = actionEvent;

        public static implicit operator ActionEventBus<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action) => new ActionEventBus<T1, T2, T3, T4, T5, T6>(action);

        public void Clear() => m_ActionEvent = null;
        public void Subscribe(Action<T1, T2, T3, T4, T5, T6> trigger) => m_ActionEvent += trigger;

        public void Unsubscribe(Action<T1, T2, T3, T4, T5, T6> trigger) => m_ActionEvent -= trigger;

        public void Subscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4, T5, T6> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4, T5, T6>)} type");
            Subscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>.Instance.Recycle(trigger);
        }

        public void Unsubscribe<TNotification>(IEventHandleable<TNotification> eventHandle) where TNotification : INotification
        {
            if (!(eventHandle is MethodEventWrapper<T1, T2, T3, T4, T5, T6> trigger))
                throw new ArgumentException($"EventHandle is not {typeof(MethodEventWrapper<T1, T2, T3, T4, T5, T6>)} type");
            Unsubscribe(trigger.Trigger);
            MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>.Instance.Recycle(trigger);
        }

        public void Publish<TNotification>(TNotification arg) where TNotification : INotification
        {
            if (!(arg is EventArgument<T1, T2, T3, T4, T5, T6> parameters))
                throw new ArgumentException($"Notification is not {typeof(EventArgument<T1, T2, T3, T4, T5, T6>)} type");
            m_ActionEvent.Invoke(parameters.Parameter1, parameters.Parameter2, parameters.Parameter3, parameters.Parameter4, parameters.Parameter5, parameters.Parameter6);
            EventArgumentPool<T1, T2, T3, T4, T5, T6>.Instance.Recycle(parameters);
        }
    }
}