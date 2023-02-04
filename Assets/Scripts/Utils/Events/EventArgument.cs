using System;
using System.Collections.Generic;

namespace Utils
{
    #region EventArgument

    public class EventArgument<T> : INotification
    {
        public T Parameter;

        public EventArgument(T parameter) => Parameter = parameter;

        public static implicit operator EventArgument<T>(T parameter) => new EventArgument<T>(parameter);

        internal void Clear() => Parameter = default;
    }

    public class EventArgument<T1, T2> : INotification
    {
        public T1 Parameter1;
        public T2 Parameter2;

        public EventArgument(T1 parameter1, T2 parameter2)
        {
            Parameter2 = parameter2;
            Parameter1 = parameter1;
        }

        public static implicit operator EventArgument<T1, T2>((T1, T2) parameter)
        {
            return new EventArgument<T1, T2>(parameter.Item1, parameter.Item2);
        }

        internal void Clear()
        {
            Parameter2 = default;
            Parameter1 = default;
        }
    }

    public class EventArgument<T1, T2, T3> : INotification
    {
        public T1 Parameter1;
        public T2 Parameter2;
        public T3 Parameter3;

        public EventArgument(T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Parameter3 = parameter3;
            Parameter2 = parameter2;
            Parameter1 = parameter1;
        }

        public static implicit operator EventArgument<T1, T2, T3>((T1, T2, T3) parameter)
        {
            return new EventArgument<T1, T2, T3>(parameter.Item1, parameter.Item2, parameter.Item3);
        }

        internal void Clear()
        {
            Parameter3 = default;
            Parameter2 = default;
            Parameter1 = default;
        }
    }

    public class EventArgument<T1, T2, T3, T4> : INotification
    {
        public T1 Parameter1;
        public T2 Parameter2;
        public T3 Parameter3;
        public T4 Parameter4;

        public EventArgument(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Parameter4 = parameter4;
            Parameter3 = parameter3;
            Parameter2 = parameter2;
            Parameter1 = parameter1;
        }

        public static implicit operator EventArgument<T1, T2, T3, T4>((T1, T2, T3, T4) parameter)
        {
            return new EventArgument<T1, T2, T3, T4>(parameter.Item1, parameter.Item2, parameter.Item3, parameter.Item4);
        }

        internal void Clear()
        {
            Parameter4 = default;
            Parameter3 = default;
            Parameter2 = default;
            Parameter1 = default;
        }
    }

    public class EventArgument<T1, T2, T3, T4, T5> : INotification
    {
        public T1 Parameter1;
        public T2 Parameter2;
        public T3 Parameter3;
        public T4 Parameter4;
        public T5 Parameter5;

        public EventArgument(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            Parameter5 = parameter5;
            Parameter4 = parameter4;
            Parameter3 = parameter3;
            Parameter2 = parameter2;
            Parameter1 = parameter1;
        }

        public static implicit operator EventArgument<T1, T2, T3, T4, T5>((T1, T2, T3, T4, T5) parameter)
        {
            return new EventArgument<T1, T2, T3, T4, T5>(parameter.Item1, parameter.Item2, parameter.Item3, parameter.Item4, parameter.Item5);
        }

        internal void Clear()
        {
            Parameter5 = default;
            Parameter4 = default;
            Parameter3 = default;
            Parameter2 = default;
            Parameter1 = default;
        }
    }

    public class EventArgument<T1, T2, T3, T4, T5, T6> : INotification
    {
        public T1 Parameter1;
        public T2 Parameter2;
        public T3 Parameter3;
        public T4 Parameter4;
        public T5 Parameter5;
        public T6 Parameter6;

        public EventArgument(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
        {
            Parameter6 = parameter6;
            Parameter5 = parameter5;
            Parameter4 = parameter4;
            Parameter3 = parameter3;
            Parameter2 = parameter2;
            Parameter1 = parameter1;
        }

        public static implicit operator EventArgument<T1, T2, T3, T4, T5, T6>((T1, T2, T3, T4, T5, T6) parameter)
        {
            return new EventArgument<T1, T2, T3, T4, T5, T6>(parameter.Item1, parameter.Item2, parameter.Item3, parameter.Item4, parameter.Item5, parameter.Item6);
        }

        internal void Clear()
        {
            Parameter1 = default;
            Parameter2 = default;
            Parameter3 = default;
            Parameter4 = default;
            Parameter5 = default;
            Parameter6 = default;
        }
    }

    #endregion

    #region Pool

    internal class EventArgumentPool<T>
    {
        private static readonly Lazy<EventArgumentPool<T>> s_Instance = new Lazy<EventArgumentPool<T>>(() => new EventArgumentPool<T>());
        public static EventArgumentPool<T> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T>> m_Pool = new Stack<EventArgument<T>>();

        public EventArgument<T> Require(T parameter1)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T>(parameter1);
        }

        public void Recycle(EventArgument<T> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    internal class EventArgumentPool<T1, T2>
    {
        private static readonly Lazy<EventArgumentPool<T1, T2>> s_Instance = new Lazy<EventArgumentPool<T1, T2>>(() => new EventArgumentPool<T1, T2>());
        public static EventArgumentPool<T1, T2> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T1, T2>> m_Pool = new Stack<EventArgument<T1, T2>>();

        public EventArgument<T1, T2> Require(T1 parameter1, T2 parameter2)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T1, T2>(parameter1, parameter2);
        }

        public void Recycle(EventArgument<T1, T2> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    internal class EventArgumentPool<T1, T2, T3>
    {
        private static readonly Lazy<EventArgumentPool<T1, T2, T3>> s_Instance = new Lazy<EventArgumentPool<T1, T2, T3>>(() => new EventArgumentPool<T1, T2, T3>());
        public static EventArgumentPool<T1, T2, T3> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T1, T2, T3>> m_Pool = new Stack<EventArgument<T1, T2, T3>>();

        public EventArgument<T1, T2, T3> Require(T1 parameter1, T2 parameter2, T3 parameter3)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T1, T2, T3>(parameter1, parameter2, parameter3);
        }

        public void Recycle(EventArgument<T1, T2, T3> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    internal class EventArgumentPool<T1, T2, T3, T4>
    {
        private static readonly Lazy<EventArgumentPool<T1, T2, T3, T4>> s_Instance = new Lazy<EventArgumentPool<T1, T2, T3, T4>>(() => new EventArgumentPool<T1, T2, T3, T4>());
        public static EventArgumentPool<T1, T2, T3, T4> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T1, T2, T3, T4>> m_Pool = new Stack<EventArgument<T1, T2, T3, T4>>();

        public EventArgument<T1, T2, T3, T4> Require(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T1, T2, T3, T4>(parameter1, parameter2, parameter3, parameter4);
        }

        public void Recycle(EventArgument<T1, T2, T3, T4> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    internal class EventArgumentPool<T1, T2, T3, T4, T5>
    {
        private static readonly Lazy<EventArgumentPool<T1, T2, T3, T4, T5>> s_Instance = new Lazy<EventArgumentPool<T1, T2, T3, T4, T5>>(() => new EventArgumentPool<T1, T2, T3, T4, T5>());
        public static EventArgumentPool<T1, T2, T3, T4, T5> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T1, T2, T3, T4, T5>> m_Pool = new Stack<EventArgument<T1, T2, T3, T4, T5>>();

        public EventArgument<T1, T2, T3, T4, T5> Require(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T1, T2, T3, T4, T5>(parameter1, parameter2, parameter3, parameter4, parameter5);
        }

        public void Recycle(EventArgument<T1, T2, T3, T4, T5> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    internal class EventArgumentPool<T1, T2, T3, T4, T5, T6>
    {
        private static readonly Lazy<EventArgumentPool<T1, T2, T3, T4, T5, T6>> s_Instance = new Lazy<EventArgumentPool<T1, T2, T3, T4, T5, T6>>(() => new EventArgumentPool<T1, T2, T3, T4, T5, T6>());
        public static EventArgumentPool<T1, T2, T3, T4, T5, T6> Instance => s_Instance.Value;
        private readonly Stack<EventArgument<T1, T2, T3, T4, T5, T6>> m_Pool = new Stack<EventArgument<T1, T2, T3, T4, T5, T6>>();

        public EventArgument<T1, T2, T3, T4, T5, T6> Require(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
        {
            return m_Pool.Count > 0
                ? m_Pool.Pop()
                : new EventArgument<T1, T2, T3, T4, T5, T6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }

        public void Recycle(EventArgument<T1, T2, T3, T4, T5, T6> argument)
        {
            argument.Clear();
            m_Pool.Push(argument);
        }
    }

    #endregion
}