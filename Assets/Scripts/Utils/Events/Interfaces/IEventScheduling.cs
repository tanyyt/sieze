using System;

namespace Utils
{
    public interface IEventScheduling<in TEventKey>
    {
        IEventBus this[TEventKey key] { get; set; }
        bool Contains(TEventKey eventKey);
        void Register(TEventKey eventKey, IEventBus eventBus);
        void Unregister(TEventKey eventKey);
        void Clear();
        void RegisterOrSubscribe(TEventKey eventKey, Action action) => this.RegisterOrSubscribe<TEventKey>(eventKey, action);
        void RegisterOrSubscribe<T>(TEventKey eventKey, Action<T> action) => this.RegisterOrSubscribe<TEventKey, T>(eventKey, action);
        void RegisterOrSubscribe<T1, T2>(TEventKey eventKey, Action<T1, T2> action) => this.RegisterOrSubscribe<TEventKey, T1, T2>(eventKey, action);
        void RegisterOrSubscribe<T1, T2, T3>(TEventKey eventKey, Action<T1, T2, T3> action) => this.RegisterOrSubscribe<TEventKey, T1, T2, T3>(eventKey, action);
        void RegisterOrSubscribe<T1, T2, T3, T4>(TEventKey eventKey, Action<T1, T2, T3, T4> action) => this.RegisterOrSubscribe<TEventKey, T1, T2, T3, T4>(eventKey, action);
        void RegisterOrSubscribe<T1, T2, T3, T4, T5>(TEventKey eventKey, Action<T1, T2, T3, T4, T5> action) => this.RegisterOrSubscribe<TEventKey, T1, T2, T3, T4, T5>(eventKey, action);
        void RegisterOrSubscribe<T1, T2, T3, T4, T5, T6>(TEventKey eventKey, Action<T1, T2, T3, T4, T5, T6> action) => this.RegisterOrSubscribe<TEventKey, T1, T2, T3, T4, T5, T6>(eventKey, action);
    }
}