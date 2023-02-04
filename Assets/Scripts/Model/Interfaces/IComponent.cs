namespace Model
{
    public interface IComponent : IEntity
    {
        public IRoot Root{get; }
        void Activate(IRoot root);
        void Deactivate();
    }
}