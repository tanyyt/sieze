namespace Model
{
    public interface IComponent : IEntity
    {
        IRoot Root{ get; }
        bool IsInConnectorRange { get; }
        void Activate(IRoot root);
        void Deactivate();
    }
}