namespace Utils
{
    public sealed class EmptyNotification : INotification
    {
        public static readonly EmptyNotification Default = new EmptyNotification();
    }
}