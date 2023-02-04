namespace Utils
{
    public interface IEventHandleable
    {
    }

    public interface IEventHandleable<in T> : IEventHandleable where T : INotification 
    {
        void Handle(T notification);
    }
}