namespace Model
{
    public interface IAttacker : IComponent
    {
        bool IsCooling { get; }
        void Attack(IRoot root);
    }
}