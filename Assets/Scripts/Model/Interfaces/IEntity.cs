using UnityEngine;

namespace Model
{
    public interface IEntity
    {
        public GameObject GameObject { get;}
        public int MaxHp { get; }
        public void Hurt(int damage);
    }
}