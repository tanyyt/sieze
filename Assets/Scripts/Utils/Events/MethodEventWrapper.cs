using System;
using System.Collections.Generic;

namespace Utils
{
    #region MethodEventWrapper

    public sealed class MethodEventWrapper : IEventHandleable<EmptyNotification>
    {
        public Action Trigger;

        public MethodEventWrapper(Action trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EmptyNotification args)
        {
            Trigger?.Invoke();
        }
    }

    public sealed class MethodEventWrapper<T> : IEventHandleable<EventArgument<T>>
    {
        public Action<T> Trigger;

        public MethodEventWrapper(Action<T> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T> args)
        {
            Trigger?.Invoke(args.Parameter);
        }
    }

    public sealed class MethodEventWrapper<T1, T2> : IEventHandleable<EventArgument<T1, T2>>
    {
        public Action<T1, T2> Trigger;

        public MethodEventWrapper(Action<T1, T2> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T1, T2> args)
        {
            Trigger?.Invoke(args.Parameter1, args.Parameter2);
        }
    }

    public sealed class MethodEventWrapper<T1, T2, T3> : IEventHandleable<EventArgument<T1, T2, T3>>
    {
        public Action<T1, T2, T3> Trigger;

        public MethodEventWrapper(Action<T1, T2, T3> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T1, T2, T3> args)
        {
            Trigger?.Invoke(args.Parameter1, args.Parameter2, args.Parameter3);
        }
    }

    public sealed class MethodEventWrapper<T1, T2, T3, T4> : IEventHandleable<EventArgument<T1, T2, T3, T4>>
    {
        public Action<T1, T2, T3, T4> Trigger;

        public MethodEventWrapper(Action<T1, T2, T3, T4> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T1, T2, T3, T4> args)
        {
            Trigger?.Invoke(args.Parameter1, args.Parameter2, args.Parameter3, args.Parameter4);
        }
    }

    public sealed class MethodEventWrapper<T1, T2, T3, T4, T5> : IEventHandleable<EventArgument<T1, T2, T3, T4, T5>>
    {
        public Action<T1, T2, T3, T4, T5> Trigger;

        public MethodEventWrapper(Action<T1, T2, T3, T4, T5> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T1, T2, T3, T4, T5> args)
        {
            Trigger?.Invoke(args.Parameter1, args.Parameter2, args.Parameter3, args.Parameter4, args.Parameter5);
        }
    }

    public sealed class MethodEventWrapper<T1, T2, T3, T4, T5, T6> : IEventHandleable<EventArgument<T1, T2, T3, T4, T5, T6>>
    {
        public Action<T1, T2, T3, T4, T5, T6> Trigger;

        public MethodEventWrapper(Action<T1, T2, T3, T4, T5, T6> trigger)
        {
            Trigger = trigger;
        }

        public void Handle(EventArgument<T1, T2, T3, T4, T5, T6> args)
        {
            Trigger?.Invoke(args.Parameter1, args.Parameter2, args.Parameter3, args.Parameter4, args.Parameter5, args.Parameter6);
        }
    }

    #endregion

    #region MethodEventWrapperPool

    internal class MethodEventWrapperPool
    {
        private static readonly Lazy<MethodEventWrapperPool> s_Instance = new Lazy<MethodEventWrapperPool>(() => new MethodEventWrapperPool());
        public static MethodEventWrapperPool Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper> m_Pool = new Stack<MethodEventWrapper>();

        public MethodEventWrapper Require(Action action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper(action);
        }

        public void Recycle(MethodEventWrapper wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T>
    {
        private static readonly Lazy<MethodEventWrapperPool<T>> s_Instance = new Lazy<MethodEventWrapperPool<T>>(() => new MethodEventWrapperPool<T>());
        public static MethodEventWrapperPool<T> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T>> m_Pool = new Stack<MethodEventWrapper<T>>();

        public MethodEventWrapper<T> Require(Action<T> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T>(action);
        }

        public void Recycle(MethodEventWrapper<T> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T1, T2>
    {
        private static readonly Lazy<MethodEventWrapperPool<T1, T2>> s_Instance = new Lazy<MethodEventWrapperPool<T1, T2>>(() => new MethodEventWrapperPool<T1, T2>());
        public static MethodEventWrapperPool<T1, T2> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T1, T2>> m_Pool = new Stack<MethodEventWrapper<T1, T2>>();

        public MethodEventWrapper<T1, T2> Require(Action<T1, T2> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T1, T2>(action);
        }

        public void Recycle(MethodEventWrapper<T1, T2> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T1, T2, T3>
    {
        private static readonly Lazy<MethodEventWrapperPool<T1, T2, T3>> s_Instance = new Lazy<MethodEventWrapperPool<T1, T2, T3>>(() => new MethodEventWrapperPool<T1, T2, T3>());
        public static MethodEventWrapperPool<T1, T2, T3> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T1, T2, T3>> m_Pool = new Stack<MethodEventWrapper<T1, T2, T3>>();

        public MethodEventWrapper<T1, T2, T3> Require(Action<T1, T2, T3> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T1, T2, T3>(action);
        }

        public void Recycle(MethodEventWrapper<T1, T2, T3> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T1, T2, T3, T4>
    {
        private static readonly Lazy<MethodEventWrapperPool<T1, T2, T3, T4>> s_Instance = new Lazy<MethodEventWrapperPool<T1, T2, T3, T4>>(() => new MethodEventWrapperPool<T1, T2, T3, T4>());
        public static MethodEventWrapperPool<T1, T2, T3, T4> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T1, T2, T3, T4>> m_Pool = new Stack<MethodEventWrapper<T1, T2, T3, T4>>();

        public MethodEventWrapper<T1, T2, T3, T4> Require(Action<T1, T2, T3, T4> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T1, T2, T3, T4>(action);
        }

        public void Recycle(MethodEventWrapper<T1, T2, T3, T4> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T1, T2, T3, T4, T5>
    {
        private static readonly Lazy<MethodEventWrapperPool<T1, T2, T3, T4, T5>> s_Instance = new Lazy<MethodEventWrapperPool<T1, T2, T3, T4, T5>>(() => new MethodEventWrapperPool<T1, T2, T3, T4, T5>());
        public static MethodEventWrapperPool<T1, T2, T3, T4, T5> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T1, T2, T3, T4, T5>> m_Pool = new Stack<MethodEventWrapper<T1, T2, T3, T4, T5>>();

        public MethodEventWrapper<T1, T2, T3, T4, T5> Require(Action<T1, T2, T3, T4, T5> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T1, T2, T3, T4, T5>(action);
        }

        public void Recycle(MethodEventWrapper<T1, T2, T3, T4, T5> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    internal class MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>
    {
        private static readonly Lazy<MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>> s_Instance = new Lazy<MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>>(() => new MethodEventWrapperPool<T1, T2, T3, T4, T5, T6>());
        public static MethodEventWrapperPool<T1, T2, T3, T4, T5, T6> Instance => s_Instance.Value;
        private readonly Stack<MethodEventWrapper<T1, T2, T3, T4, T5, T6>> m_Pool = new Stack<MethodEventWrapper<T1, T2, T3, T4, T5, T6>>();

        public MethodEventWrapper<T1, T2, T3, T4, T5, T6> Require(Action<T1, T2, T3, T4, T5, T6> action)
        {
            return m_Pool.Count > 0 ? m_Pool.Pop() : new MethodEventWrapper<T1, T2, T3, T4, T5, T6>(action);
        }

        public void Recycle(MethodEventWrapper<T1, T2, T3, T4, T5, T6> wrapper)
        {
            wrapper.Trigger = null;
            m_Pool.Push(wrapper);
        }
    }

    #endregion
}