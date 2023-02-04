namespace Model
{
    public interface IComponent : IEntity
    {
        public IRoot Root{get; }
        void Initialize(IRoot root);
    }
}