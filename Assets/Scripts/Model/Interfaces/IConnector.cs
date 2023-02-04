namespace Model
{
    public interface IConnector
    {
        void Connect(IComponent component);
        bool LostConnect(IComponent component);
    }
}