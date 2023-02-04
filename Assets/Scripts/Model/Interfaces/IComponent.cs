namespace Model
{
    public interface IComponent : IEntity
    {
        IRoot Root { get; }
        IConnector Connector { get; }
        bool IsInConnectorRange { get; }
        void Activate(IRoot root, IConnector connector);
        void Deactivate();
    }
}