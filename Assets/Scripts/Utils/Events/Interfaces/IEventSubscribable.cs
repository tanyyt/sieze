namespace Utils
{
    public interface IEventSubscribable
    {
        void Subscribe<T>(IEventHandleable<T> eventHandle) where T : INotification;
        void Unsubscribe<T>(IEventHandleable<T> eventHandle) where T : INotification;
        void Clear();
    }
}