namespace Model
{
    public interface IEntity
    {
        public int MaxHp { get; }
        public void Hurt(int damage);
    }
}