namespace Utils
{
    public interface IEventPublishable
    {
        void Publish<T>(T notification) where T : INotification;
    }
}